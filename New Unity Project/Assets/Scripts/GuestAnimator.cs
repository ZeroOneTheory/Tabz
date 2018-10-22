using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuestAnimator : MonoBehaviour {

    Animator anim;
    [Range(0,2)]
    [SerializeField] int animNum;

    private void Awake() {
        anim = GetComponent<Animator>();
    }
    private void Update() {
        if (GameManager.Instance.InputController.tempKey) {
            if (animNum == int.MaxValue) {
                animNum = 0;
            } else { animNum += 1; }
           
        }
    }
}
