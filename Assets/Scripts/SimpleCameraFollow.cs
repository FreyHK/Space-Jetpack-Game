using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleCameraFollow : MonoBehaviour {

    public Transform target;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 pos = new Vector3(target.position.x, target.position.y, -1f);
        transform.position = pos;
	}
}
