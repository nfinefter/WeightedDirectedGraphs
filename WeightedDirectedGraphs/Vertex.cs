using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace WeightedDirectedGraphs
{
    class Vertex<T> : IComparable<Vertex<T>>
    {
        public T Value { get; set; }
        public List<Edge<T>> Neighbors { get; set; }

        public int NeighborCount => Neighbors.Count;
        public Vertex<T> Parent;
        public bool Visited = false;
        public float Distance = float.PositiveInfinity;

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

        public int CompareTo(Vertex<T> other)
        {
            
            if (other.Distance.Equals(Distance))
            {
                return 0;
            }
            if (other.Distance < Distance)
            {
                return 1;
            }
            if (other.Distance > Distance)
            {
                return -1;
            }

            return 0;
        }
    }
}
