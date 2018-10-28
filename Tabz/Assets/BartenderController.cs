using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BartenderController : MonoBehaviour {

    public Dictionary<string, GameObject> DrinkMenu = new Dictionary<string, GameObject>();
    public MenuItem[] menuItems;

    private void Start() {
        for(int x=0; x<menuItems.Length; x++) {
            DrinkMenu.Add(menuItems[x].itemName, menuItems[x].prefabParent);
        }
    }

    void Update () {
        if (GameManager.Instance.InputController.spaceKey) {
         
           //add new drink order to inventory
        }
	}

    [Serializable]
    public struct MenuItem {
        public string itemName;
        public GameObject prefabParent;
    }
}
