using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class RandomWorldGenerator : MonoBehaviour
{

    public int mapSeed;
    public int mapHeight;
    public int mapWidth;

    private int[] mapValues;

    // height map values: ocean, coast, land, hills, mountains
    private int[] heightMap;
    

    void Start ()
    {
        Random.seed = mapSeed;
        mapValues = new int[mapWidth * mapHeight];
        heightMap = new int[mapWidth * mapHeight];

        // default world to ocean
        for (int i = 0; i < heightMap.Length; i++)
            heightMap[i] = -1;
	}

    void Update()
    {
	
	}

    void CreateMap()
    {
        // create seed islands

        // 
    }


    void WriteToFile()
    {
        // save the generated map to a file
    }
}
