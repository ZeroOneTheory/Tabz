using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton
    public static Inventory instance;
    private void Awake() {
        if (instance != null) { Debug.LogWarning("More than 1 inventory found!"); }
        instance = this;
    }
    #endregion

    // Delegate callback for when the rail has updated
    public delegate void OnRailChanged();
    public OnRailChanged railChangedCallback;

    // ------ Rail Inventory ---------- // 
    public int railLength;  // Rails total length
    public bool isRailFull=false; // Full rail bool, if all positions are occupied
    public Transform[] railPositions; // Array of all the saved transform positions for the Rail
    public List<GameObject> theRail = new List<GameObject>(); //List of Drink Objects on the rail

    private void Start() {
        railLength = railPositions.Length;
        railChangedCallback += AddToRail; // Call the AddtoRail function, whenever the rail has changed
    }

    public void Update() {
        //Check if the rail is occupied
        if(theRail.Count < railPositions.Length) { isRailFull = false; } else { isRailFull = true; }
    }


    /// <summary>
    ///  Adds a new drink to rail if there's room, returns true if successful
    /// </summary>
    /// <param name="newOrder"></param>
    /// <returns></returns>
    public bool NewDrinkOrder(GameObject newOrder) {
        // if the list is not full
        if (isRailFull==false) {
            theRail.Add(newOrder); // add the order to the rail
            DrinkOrders ticket = newOrder.GetComponent<DrinkOrders>(); // add the DrinkOrder Component
            ticket.onRail = true; // set the ticket to onRail
            ticket.railPosition = theRail.IndexOf(newOrder); // Save the tickets rail position

            // Subscribe to rail change callback event
            if(railChangedCallback != null) {
                railChangedCallback.Invoke();
            }
            return true;
        } else {
            Debug.Log("Rail Full");
            return false;
        }

    }

    /// <summary>
    ///  Sets the positions of items added to the rail to the positions stored in the railPositions array
    /// </summary>
    public void AddToRail() {
        for (int i = 0; i < theRail.Count; i++) {
            if (i > railPositions.Length) { break; }
            theRail[i].transform.position = railPositions[i].position;
            
        }
    }


}
