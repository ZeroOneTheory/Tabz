using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartenderController : MonoBehaviour {

    public Dictionary<string, GameObject> DrinkMenu = new Dictionary<string, GameObject>();
    public MenuItem[] menuItems;
    public string requestOrderKey;
    public int tempStringRequest;

    private void Start() {
        for(int x=0; x<menuItems.Length; x++) {
            DrinkMenu.Add(menuItems[x].itemName, menuItems[x].prefabParent);
        }
    }

    void Update () {
        
    }

    public void AcceptNewOrder() {

        string orderString;
        NextOrder();
        orderString = menuItems[tempStringRequest].itemName;

            if (Inventory.instance.isRailFull == false) {
                // Take order string and create empty game object
                requestOrderKey = orderString;
                GameObject temp = null;

                // if Order key returns a valid drink on the menu instantiate it and add drink order component 
                if (DrinkMenu.TryGetValue(requestOrderKey, out temp)) {
                    GameObject TempObj = Instantiate(DrinkMenu[requestOrderKey]);
                    TempObj.gameObject.AddComponent<DrinkOrders>();
                    // If the item is successfully added to the rail, return true if not return false
                    if (Inventory.instance.NewDrinkOrder(TempObj)) {
                        Debug.Log("Accepting new order of:" + requestOrderKey);
                    }
                }
                else { Debug.Log("Item Not On Menu!"); }
            }
        }

    public void NextOrder() {
        if (tempStringRequest == menuItems.Length-1) {
            tempStringRequest = 0;
        } else { tempStringRequest += 1; }
        
    }
}




    [Serializable]
    public struct MenuItem {
        public string itemName;
        public GameObject prefabParent;
    }

