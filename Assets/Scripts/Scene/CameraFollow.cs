using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Camera cam;
    public Transform target;

    float minY;
    float yOffset = 2f;
    float worldWidth = 10f;
	
	void Start () {
        //Calculate camera orthographic size
        float aspect = (float)Screen.height / Screen.width;

        cam.orthographicSize = aspect * worldWidth / 2f;

        minY = cam.orthographicSize;

        transform.position = new Vector3(0f, Mathf.Max(target.position.y + yOffset, minY), -10f);
    }

    Vector3 currentVelocity;

	void LateUpdate () {
        if (target == null)
            return;

        Vector3 targetPos = new Vector3(0f, Mathf.Max(target.position.y + yOffset, minY), -10f);

        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref currentVelocity, .2f);
	}
}
