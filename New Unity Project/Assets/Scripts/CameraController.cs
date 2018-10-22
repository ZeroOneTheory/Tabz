using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    InputController inputControl;

    [SerializeField] float pitch;
    [SerializeField] float yaw;
    [SerializeField] float viewUpDown;
    [SerializeField] float camSpeed;


    private float vertRequest;
    private float currentVertical;
    Animator anim;

    private void Awake() {
        inputControl = GameManager.Instance.InputController;
        anim = gameObject.GetComponent<Animator>();
        viewUpDown = -1;
    }

    void Update() {

        if (inputControl.vertical != 0) { vertRequest = inputControl.vertical; }
        if (currentVertical != vertRequest) {
            currentVertical = Mathf.SmoothStep(currentVertical, vertRequest, camSpeed * Time.deltaTime);
        }
        anim.SetFloat("vertical", currentVertical);

    }
}
