using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Delaunay;
using Delaunay.Geo;


public class RandomWorldGenerator : MonoBehaviour
{

    public int mapSeed;
    public int mapHeight;
    public int mapWidth;
    public int numSeeds = 4096;

    private int[] mapValues;

    // seed points to start the map generation
    private List<Vector2> seedPoints;

    // status message for displaying to the screen
    private string statusMessage;

    void Start()
    {
        UnityEngine.Random.seed = mapSeed;
        mapValues = new int[mapWidth * mapHeight];

        seedPoints = new List<Vector2>(numSeeds);

        statusMessage = "Creating a new world based on seed...";
    }

    void Update()
    {

    }


    void CreateMap()
    {
        // generate random points
        for (int i = 0; i < seedPoints.Count; i++)
        {
            int rX = UnityEngine.Random.Range(0, mapWidth);
            int rY = UnityEngine.Random.Range(0, mapHeight);

            seedPoints[i] = new Vector2(rX, rY);
        }

        // generate voronoi using fortune's algorithm

    }





    void WriteToFile()
    {
        // save the generated map to a file
    }
}
