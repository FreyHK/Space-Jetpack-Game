using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetpackInput : MonoBehaviour {

	public int GetHorizontalInput () {
        int inp = 0;

        if (Input.GetKey(KeyCode.RightArrow))
            inp = 1;
        else if (Input.GetKey(KeyCode.LeftArrow))
            inp = -1;

        if (!IsTouchingWall(inp))
            return inp;

        return 0;
        //return Input.GetAxis("Horizontal");
    }

    public LayerMask wallCheckMask;

    float checkStart = .2f;
    float checkWidth = .05f;
    float checkHeight = .65f;

    bool IsTouchingWall (int inp) {
        Vector2 origin = new Vector2(transform.position.x + checkStart * inp, transform.position.y);
        Vector2 size = new Vector2(checkWidth, checkHeight);

        RaycastHit2D hit = Physics2D.BoxCast(origin, size, 0f, Vector2.zero, 1f, wallCheckMask);

        return hit.collider != null;
    }

    private void OnDrawGizmos() {
        Vector3 origin = new Vector3(transform.position.x + checkStart, transform.position.y);
        Vector3 size = new Vector3(checkWidth, checkHeight, 1f);

        Gizmos.DrawCube(origin, size);
    }

    public bool GetThrusterInput() {
        return Input.GetKey(KeyCode.DownArrow);
    }

    public bool GetJump() {
        return Input.GetKeyDown(KeyCode.UpArrow);
    }

    public bool GetAirJump() {
        return Input.GetKeyUp(KeyCode.UpArrow);
    }
}
