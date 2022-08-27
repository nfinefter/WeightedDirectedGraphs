using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraphs
{
    class Edge<T>
    {
        public Vertex<T> StartingPoint { get; set; }
        public Vertex<T> EndingPoint { get; set; }
        public float Weight { get; set; }

        public Edge(Vertex<T> startingPoint, Vertex<T> endingPoint, float distance)
        {
            StartingPoint = startingPoint;
            EndingPoint = endingPoint;
            Weight = distance;
            //how to make distance infinity
        }
    }
}
