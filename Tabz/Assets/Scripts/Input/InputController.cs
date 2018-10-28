using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {

    public float vertical;
    public float horizontal;
    public float scrollZoom;
    public bool leftMouse;
    public bool IncViewKey;
    public bool DecViewKey;
    public bool spaceKey;
    public Vector2 mouseInput;
    public Vector2 inputDir;


    private void Update() {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y"));
        leftMouse = Input.GetMouseButtonDown(0);
        IncViewKey = Input.GetKeyDown(KeyCode.Z);
        DecViewKey = Input.GetKeyDown(KeyCode.X);
        spaceKey = Input.GetKeyUp(KeyCode.Space);

    }
}
