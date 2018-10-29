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

    public delegate void OnRailChanged();
    public OnRailChanged railChangedCallback;

    public int railLength;
    public bool isRailFull=false;
    public Transform[] railPositions;
    public List<GameObject> theRail = new List<GameObject>();

    private void Start() {
        railLength = railPositions.Length;
        railChangedCallback += AddToRail;
    }

    public void Update() {
        if(theRail.Count < railPositions.Length) { isRailFull = false; } else { isRailFull = true; }
    }


    public bool NewDrinkOrder(GameObject newOrder) {
        if (theRail.Count < railLength) {
            theRail.Add(newOrder);
            DrinkOrders ticket = newOrder.GetComponent<DrinkOrders>();
            ticket.onRail = true;
            ticket.railPosition = theRail.IndexOf(newOrder);
            if(railChangedCallback != null) {
                railChangedCallback.Invoke();
            }
            return true;
        } else {
            Debug.Log("Rail Full");
            return false;
        }

    }

    public void AddToRail() {
        for (int i = 0; i < theRail.Count; i++) {
            if (i > railPositions.Length) { break; }
            theRail[i].transform.position = railPositions[i].position;
            
        }
    }


}
