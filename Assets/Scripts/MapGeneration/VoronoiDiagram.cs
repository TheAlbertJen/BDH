using UnityEngine;
using System;
using System.Collections.Generic;

using Delaunay;
using Delaunay.Geo;

namespace Assets.Scripts.MapGeneration
{
    class VoronoiDiagram
    {
        public Voronoi voronoi;
        private int mapWidth;
        private int mapHeight;

        public VoronoiDiagram(List<Vector2> points, int width, int height)
        {
            List<uint> colors = new List<uint>();
            mapWidth = width;
            mapHeight = height;

            for (int i = 0; i < points.Count; i++)
                colors.Add(0);

            voronoi = new Voronoi(points, colors,
                new Rect(0, 0, mapWidth, mapHeight));
        }

        /// <summary>
        /// Runs a set number of iterations of Lloyd relaxation on the current
        /// Voronoi diagram.
        /// </summary>
        /// <param name="iterCount"></param>
        public void LloydRelaxation(int iterCount = 1)
        {
            for (int i = 0; i < iterCount; i++)
            {
                var centroids = GetCentroids();
                voronoi = new Voronoi(centroids, voronoi.SiteColors(),
                    voronoi.plotBounds);
            }
        }

        /// <summary>
        /// Gets the centroids of all the currently calculated Voronoi
        /// regions.
        /// </summary>
        /// <returns>a list of the centroids (Vector2)</returns>
        private List<Vector2> GetCentroids()
        {
            List<Vector2> centroids = new List<Vector2>();

            // algorithm for finding centroids
            // get verts per site
            // average verts
            foreach (var site in voronoi.SiteCoords())
            {
                var verts = voronoi.Region(site);
                Vector2 centroid = new Vector2(0,0);
                foreach (var vert in verts)
                {
                    centroid.x += vert.x;
                    centroid.y += vert.y;
                }
                centroid.x = centroid.x / verts.Count;
                centroid.y = centroid.y / verts.Count;

                centroids.Add(centroid);
            }

            return centroids;
        }

        /// <summary>
        /// Checks to see if a given point lies within a Voronoi region.
        /// </summary>
        /// <param name="pointToCheck"></param>
        /// <returns>index of site that owns encapsulating voronoi region,
        /// -1 if not in a region.</returns>
        public Vector2 IsInRegion(Vector2 pointToCheck)
        {
            if (pointToCheck.x < 0 || pointToCheck.x > mapWidth ||
                pointToCheck.y < 0 || pointToCheck.y > mapHeight)
            {
                throw new Exception("pointToCheck is out of bounds.");
            }
            var site = voronoi.NearestSitePoint(pointToCheck.x, pointToCheck.y);
            if (site.HasValue)
                return site.Value;
            else
                throw new Exception("NearestSitePoint returned null value.");

        }
    }
}
