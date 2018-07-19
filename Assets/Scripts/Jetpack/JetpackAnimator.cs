using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackAnimator : MonoBehaviour {

    public Animator animator;

    //Get mirrored depending on move direction
    public Transform graphics;

    public void DoUpdate (float moveX) {
        if (moveX > 0) {
            graphics.rotation = Quaternion.Euler(0f, 0f, 0f);
        } else if (moveX < 0){
            graphics.rotation = Quaternion.Euler(0f, 180f, 0f);
        }
    }
}
