using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform[] barViews;
    public float transitionSpeed;
    public Transform currentView;
    public int viewNumber = 0;

    InputController inputControl;


    void Start() {
        inputControl = GameManager.Instance.InputController;
    }

    void Update() {
        if (inputControl.tempKey) {
            if (viewNumber == barViews.Length-1) {
                viewNumber = 0;
            } else { viewNumber += 1; }
        }
        currentView = barViews[viewNumber];
    }

    void LateUpdate() {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentView.rotation, Time.deltaTime * transitionSpeed);

    }

}
