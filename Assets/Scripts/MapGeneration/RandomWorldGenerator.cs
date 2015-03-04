using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using System.IO;

namespace Assets.Scripts.MapGeneration
{


    public class RandomWorldGenerator : MonoBehaviour
    {

        public int mapSeed;
        public int mapHeight;
        public int mapWidth;
        public int numSeeds = 4096;

        private VoronoiDiagram vd;

        // seed points to start the map generation
        private List<Vector2> seedPoints;

        // status message for displaying to the screen
        public string statusMessage;

        void Start()
        {
            UnityEngine.Random.seed = mapSeed;

            seedPoints = new List<Vector2>(numSeeds);

            statusMessage = "Creating a new world based on seed...";
        }

        void CreateMap()
        {
            List<uint> colors = new List<uint>();
            statusMessage = "Generating seed points...";
            // generate random points
            for (int i = 0; i < seedPoints.Count; i++)
            {
                colors.Add(0);
                int rX = UnityEngine.Random.Range(0, mapWidth);
                int rY = UnityEngine.Random.Range(0, mapHeight);

                seedPoints[i] = new Vector2(rX, rY);
            }

            // generate voronoi diagram
            statusMessage = "Creating Voronoi diagram based of seeds...";
            vd = new VoronoiDiagram(seedPoints, mapWidth, mapHeight);
            statusMessage = "Relaxing seed points...";
            vd.LloydRelaxation(2);
        }

        public void LoadFromFile()
        {

        }

        public void SaveToFile()
        {
            // save the generated map to a file
        }

        public void SaveToImageFile()
        {
            // save the generated map to an image
        }
    }
}