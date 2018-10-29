using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(DrinkBuild))]
public class DrinkOrders : MonoBehaviour {

    public bool onRail = false;
    public int railPosition;
    public DrinkBuild orderRequested;


	// Use this for initialization
	void Start () {
        orderRequested = GetComponent<DrinkBuild>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
