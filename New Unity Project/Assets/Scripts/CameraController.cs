using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    InputController inputControl;

    [SerializeField] float pitch;
    [SerializeField] float yaw;
    [SerializeField] float viewUpDown;
    Animator anim;

    private void Awake() {
        inputControl = GameManager.Instance.InputController;
        anim = gameObject.GetComponent<Animator>();
        viewUpDown = -1;
    }

    private void Update() {
        
        anim.SetFloat("direction", viewUpDown);
        if (Input.GetKeyDown(KeyCode.A)) {
            if(viewUpDown < 1) { viewUpDown = 1; } else { viewUpDown = -1; }
            anim.Play("CameraToWell");
            anim.playbackTime = viewUpDown;
        }

    }
}
