using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    InputController inputControl;

    [SerializeField] float pitch;
    [SerializeField] float yaw;

    private void Awake() {
        inputControl = GameManager.Instance.InputController;
    }

    private void Update() {
        yaw = inputControl.mouseInput.y;
    }
}
