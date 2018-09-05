using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapGenerator : MonoBehaviour {

    [SerializeField]
    Tilemap tilemap;
    [SerializeField]
    TileBase tile;

    void Start() {
        int[,] map = new int[50, 100];
        for (int x = 0; x < map.GetUpperBound(0); x++) {
            for (int y = 0; y < map.GetUpperBound(1); y++) {
                map[x, y] = 1;
            }
        }

        map = DirectionalTunnel(map, 1, 3, 1, 30, 60);
        Rendermap(map, tilemap, tile);
    }

    public static void Rendermap(int[,] map, Tilemap tilemap, TileBase tile) {
        //Clear the map (ensures we dont overlap)
        tilemap.ClearAllTiles();
        //Loop through the width of the map
        for (int x = 0; x < map.GetUpperBound(0); x++) {
            //Loop through the height of the map
            for (int y = 0; y < map.GetUpperBound(1); y++) {
                // 1 = tile, 0 = no tile
                if (map[x, y] == 1) {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                }
            }
        }
    }

    public static void UpdateMap(int[,] map, Tilemap tilemap) { //Takes in our map and tilemap, setting null tiles where needed
        for (int x = 0; x < map.GetUpperBound(0); x++) {
            for (int y = 0; y < map.GetUpperBound(1); y++) {
                //We are only going to update the map, rather than rendering again
                //This is because it uses less resources to update tiles to null
                //As opposed to re-drawing every single tile (and collision data)
                if (map[x, y] == 0) {
                    tilemap.SetTile(new Vector3Int(x, y, 0), null);
                }
            }
        }
    }


    public static int[,] DirectionalTunnel(int[,] map, int minPathWidth, int maxPathWidth, int maxPathChange, int roughness, int curvyness) {
        //This value goes from its minus counterpart to its positive value, in this case with a width value of 1, the width of the tunnel is 3
        int tunnelWidth = 1;
        //Set the start X position to the center of the tunnel
        int x = map.GetUpperBound(0) / 2;

        //Set up our random with the seed
        System.Random rand = new System.Random(Time.time.GetHashCode());

        //Create the first part of the tunnel
        for (int i = -tunnelWidth; i <= tunnelWidth; i++) {
            map[x + i, 0] = 0;
        }

        for (int y = 1; y < map.GetUpperBound(1); y++) {
            //Check if we can change the roughness
            if (rand.Next(0, 100) < roughness) {
                //Get the amount we will change for the width
                int widthChange = Random.Range(-maxPathWidth, maxPathWidth);
                
                //Add it to our tunnel width value
                tunnelWidth += widthChange;

                //Check to see we arent making the path too small
                if (tunnelWidth < minPathWidth)
                    tunnelWidth = minPathWidth;

                //Check that the path width isnt over our maximum
                if (tunnelWidth > maxPathWidth)
                    tunnelWidth = maxPathWidth;
            }

            //Check if we can change the curve
            if (rand.Next(0, 100) < curvyness) {
                //Get the amount we will change for the x position
                int xChange = Random.Range(-maxPathChange, maxPathChange + 1);
                
                //Add it to our x value
                x += xChange;
                
                //Check we arent too close to the left side of the map
                if (x < maxPathWidth + 1)
                    x = maxPathWidth + 1;

                //Check we arent too close to the right side of the map
                if (x > (map.GetUpperBound(0) - maxPathWidth -1))
                    x = map.GetUpperBound(0) - maxPathWidth - 1;
            }

            //Work through the width of the tunnel
            for (int i = -tunnelWidth; i <= tunnelWidth; i++) {
                map[x + i, y] = 0;
            }
        }
        return map;
    }
}
