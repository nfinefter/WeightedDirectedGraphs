using Heap_Tree;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WeightedDirectedGraphs
{
    public class AStar
    {
        Heap<Vertex<Point>> queue;
        Vertex<Point> Start;
        Vertex<Point> End;
        Vertex<Point> vertex;
        List<Vertex<Point>> path = new List<Vertex<Point>>();

    }
}
