using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DrinkBuild))]
public class DrinkOrders : MonoBehaviour {

    public bool onRail = false;
    public int railPosition;
    public DrinkBuild orderRequested; // The Drink being built by the player
    public Drink ticket; // Copy of the original order


	// Use this for initialization
	void Start () {
        orderRequested = GetComponent<DrinkBuild>();
        ticket = orderRequested.order;
	}
	

    //Meth: Compare order to ticket
    //Meth: Pass out Drink
}
