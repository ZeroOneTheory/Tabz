﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    public Transform[] barViews;
    public Transform currentView;
    public CameraView[] cameraViews;
    public int viewNumber = 0;
    public float transitionSpeed;
    public float cameraZoom;


    InputController inputControl;
    SwipeViews swipeViews;


    void Start() {
        inputControl = GameManager.Instance.InputController;
        swipeViews = GetComponent<SwipeViews>();
    }
    void Update() {
        CycleViews();
        ChangeViews();
    }
    void LateUpdate() {
        PanCamera();
    }


    private void ChangeViews() {
        if (swipeViews.swipeDown == true) {
            if (viewNumber == 0) {
                viewNumber = 1;
            }
            else if (viewNumber == 3) {
                viewNumber = 2;
            }
        }
        if (swipeViews.swipeUp == true) {
            if (viewNumber == 1) {
                viewNumber = 0;
            }
            else if (viewNumber == 2) {
                viewNumber = 3;
            }
        }
        if (swipeViews.swipeLeft == true || swipeViews.swipeRight == true) {
            if (viewNumber == 0 || viewNumber == 1) {
                viewNumber = 2;
            }
            else if (viewNumber == 2 || viewNumber == 3) {
                viewNumber = 0;
            }
        }
    }

    private void PanCamera() {
        transform.position = Vector3.Lerp(transform.position, currentView.position, Time.deltaTime * transitionSpeed);
        transform.rotation = Quaternion.Lerp(transform.rotation, currentView.rotation, Time.deltaTime * transitionSpeed);
    }

    private void CycleViews() {

        if (inputControl.IncViewKey) {
            if (viewNumber == barViews.Length - 1) {
                viewNumber = 0;
            }
            else { viewNumber += 1; }
        }
        currentView = barViews[viewNumber];

        if (inputControl.DecViewKey) {
            if (viewNumber == 0) {
                viewNumber = barViews.Length - 1;
            }
            else { viewNumber -= 1; }
        }
        currentView = barViews[viewNumber];
    }

    public void SetViewWell() {
        viewNumber = 1;
    }


    // --------------- Classes -------------------------------
    public class CameraView {
        public enum BarViews { crowd, well, tap, topShelf, rail }
        public BarViews barView;
        public Transform camFocus;

    }



}
