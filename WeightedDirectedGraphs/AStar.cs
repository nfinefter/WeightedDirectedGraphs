using Heap_Tree;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace WeightedDirectedGraphs
{
    public enum ColorToBrush
    {
        Queued,
        Visited,
        FinalPath
    }
    public record class AStarInfo(ColorToBrush color, Point pos)
    {

    }
}
