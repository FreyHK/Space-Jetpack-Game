using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Controls chunks and places player at correct position
/// </summary>
public class MapGenerator : MonoBehaviour {

    //A 'chunk' of the map
    public TilemapGenerator generatorPrefab;

    [SerializeField]
    Transform player;

    int ChunkWidth = 50;
    int ChunkHeight = 100;

	void Start () {

        //The width of the tunnel
        int width = 1;
        //Where the tunnel starts
        int startX = ChunkWidth / 2;

        for (int i = 0; i < 2; i++) {
            //Spawn it
            TilemapGenerator t = SpawnChunk(i, width, startX);
            //Set values
            width = t.TunnelWidth;
            startX = t.EndX;
        }

        Vector3 pos = new Vector3(ChunkWidth/2 - 3f, 2f);
        player.position = pos;
    }
	
	void Update () {
		
	}

    TilemapGenerator SpawnChunk (int depth, int tunnelWidth, int startX) {
        TilemapGenerator tilemap = Instantiate(generatorPrefab, transform);
        tilemap.transform.position = new Vector3(0f, -depth * (ChunkHeight-1));

        tilemap.Init(50, 100, 1, 3, 1, 30, 60);
        bool isSurface = (depth == 0);
        tilemap.GenerateTilemap(tunnelWidth, startX, isSurface);

        return tilemap;
    }
}
