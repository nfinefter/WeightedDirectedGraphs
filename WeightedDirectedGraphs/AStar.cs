using Heap_Tree;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WeightedDirectedGraphs
{
    public record class AStarInfo(Heap<Vertex<Point>> Queue, Vertex<Point> Vertex, List<Vertex<Point>> Path)
    {
        Vertex<Point> Start { get; set; }
        Vertex<Point> End { get; set; }
    }
}
