using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

    #region Singleton
    public static Inventory instance;
    private void Awake() {
        if(instance != null) { Debug.LogWarning("More than 1 inventory found!"); }
        instance = this;
    }
    #endregion

    public int railLength;
    public Transform[] railPositions;
    public List<DrinkOrders> theRail = new List<DrinkOrders>();

    private void Start() {
        railLength = railPositions.Length;
    }

    public void Update() {
        
    }


    public bool NewDrinkOrder(DrinkOrders newOrder) {
        if (theRail.Count < railLength) {
            theRail.Add(newOrder);
            newOrder.onRail = true;
            newOrder.railPosition = theRail.IndexOf(newOrder);
            Debug.Log(newOrder.order.drinkName + " " + newOrder.railPosition);
            return true;
        } else {
            Debug.Log("Rail Full");
            return false;
        }

    }

    public void AddToRail() {
        // Check for Drinks that are on list but not on rail
        // for every drink added to the rail list, that isn't already on the rail, add to phyiscal position. 
    }


}
