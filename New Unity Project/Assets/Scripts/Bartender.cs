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
        inputController = GameManager.Instance.InputController;

    }
	
	// Update is called once per frame
	void Update () {
        Ray barRay = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit barRayHitInfo;
        if (inputController.leftMouse) {
            if (Physics.Raycast(barRay, out barRayHitInfo)) {
                Debug.Log("Clicking" + barRayHitInfo.transform.name);
            }
        }
	}
}
