using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

    public MeshRenderer meshRenderer;
    public Transform player;

    Vector2 startPos;

    void Start () {
        transform.position = new Vector3(0f, player.position.y, 0f);
        startPos = (Vector2)player.position;
    }

    float size = 40f;
    float parallax = 1f;

    void Update () {
        transform.position = new Vector3(0f, player.position.y, 0f);

        meshRenderer.material.mainTextureOffset = 
            new Vector2(0f, transform.position.y / size / parallax);

    }
}
