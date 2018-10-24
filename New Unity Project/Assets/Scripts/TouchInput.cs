using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour {

    public LayerMask touchInputMask;
    public float touchDelay;

    private float nextTouchAllowed;
    private RaycastHit hit;
    [SerializeField] List<GameObject> touchList = new List<GameObject>();
    private GameObject[] touchesOld;

    Camera cam;

    public void Start() {
        cam = GetComponent<Camera>();
    }

    void Update() {

        if (Input.touchCount > 0) {

            touchesOld = new GameObject[touchList.Count];
            touchList.CopyTo(touchesOld);
            touchList.Clear();

            foreach (Touch touch in Input.touches) {
                Ray ray = cam.ScreenPointToRay(touch.position);
                

                if (Physics.Raycast(ray, out hit, touchInputMask)) {
                    GameObject recipient = hit.transform.gameObject;
                    touchList.Add(recipient);

                    if (touch.phase == TouchPhase.Began) {
                        recipient.SendMessage("OnTouchDown", hit.transform, SendMessageOptions.DontRequireReceiver);

                    }
                    if (touch.phase == TouchPhase.Ended) {
                        recipient.SendMessage("OnTouchUp", hit.transform, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Moved) {
                        recipient.SendMessage("OnTouchMoved", hit.transform, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Stationary) {
                        recipient.SendMessage("OnTouchStationary", hit.transform, SendMessageOptions.DontRequireReceiver);
                    }
                    if (touch.phase == TouchPhase.Canceled) {
                        recipient.SendMessage("OnTouchExit", hit.transform, SendMessageOptions.DontRequireReceiver);
                    }
                }


            }

            foreach (GameObject g in touchesOld) {
                if (!touchList.Contains(g)) {
                    g.SendMessage("OnTouchExit", hit.transform, SendMessageOptions.DontRequireReceiver);
                }
            }

        }


    }
}
