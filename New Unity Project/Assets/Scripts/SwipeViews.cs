using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeViews : MonoBehaviour {

    public int reqTouchToSwipe;
    public float swipeDeadZone;
    public bool invertUpDown;

    [HideInInspector]
    public bool tap, swipeLeft, swipeRight, swipeUp, swipeDown;
    private bool isDragging = false;
    public Vector2 startTouch, swipeDelta;


    private void Update() {
        tap = swipeLeft = swipeRight = swipeUp = swipeDown = false;

        if (Input.touchCount > reqTouchToSwipe) {
            if(Input.touches[0].phase == TouchPhase.Began) {
                tap = true;
                isDragging = true;
                startTouch = Input.touches[0].position;
            } else if( Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled) {
                isDragging = false;
                Reset();
            }
        }

        //calculate touch distances 
        swipeDelta = Vector2.zero;
        if(isDragging) {
            if(Input.touchCount> reqTouchToSwipe) {
                swipeDelta = Input.touches[0].position - startTouch;
            } 
        }
        //Crossed DeadZone
        if(swipeDelta.magnitude > swipeDeadZone) {

            float x = swipeDelta.x;
            float y = swipeDelta.y;

            if (invertUpDown) { y = y * -1; }

            if( Mathf.Abs(x) > Mathf.Abs(y)) {
                //Left or Right
                if (x < 0) {
                    swipeLeft = true;
                } else {
                    swipeRight = true;
                }
            } else {
                // Up or Down
                if (y < 0) {
                    swipeDown = true;
                } else {
                    swipeUp = true;
                }
            }

            Reset();
        }

    }

    private void Reset() {
        startTouch = swipeDelta = Vector2.zero;
        isDragging = false;
    }

}
