using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraphs
{
    class Vertex<T>
    {
        public T Value { get; set; }
        public List<Edge<T>> Neighbors { get; set; }

        public int NeighborCount => Neighbors.Count;
        public Vertex<T> Parent;
        public Vertex(T value) 
        {
            Neighbors = new List<Edge<T>>();
            Value = value;
            Parent = null;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
