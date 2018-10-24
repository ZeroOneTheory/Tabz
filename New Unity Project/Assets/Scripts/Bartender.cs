using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bartender : MonoBehaviour {
    [SerializeField] Camera cam;
    InputController inputController;
    CameraController camController;


    LayerMask bartending;
    LayerMask audience;
    Ray guestRay;
    RaycastHit guestRayHitInfo;


	// Use this for initialization
	void Start () {
        

    }
	
	// Update is called once per frame
	void Update () {

	}
}
