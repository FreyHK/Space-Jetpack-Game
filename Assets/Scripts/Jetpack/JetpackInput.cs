using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackInput : MonoBehaviour {

	public int GetHorizontalInput () {
        if (Input.GetKey(KeyCode.RightArrow))
            return 1;
        else if (Input.GetKey(KeyCode.LeftArrow))
            return -1;
        else
            return 0;

        //return Input.GetAxis("Horizontal");
    }

    public bool GetThrusterInput() {
        return Input.GetKey(KeyCode.DownArrow);
    }

    public bool GetJumpInput() {
        return Input.GetKeyDown(KeyCode.UpArrow);
    }
}
