using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace WeightedDirectedGraphs
{
    public class Vertex<T> : IComparable<Vertex<T>>
    {
        public T Value { get; set; }
        public List<Edge<T>> Neighbors { get; set; }

        public int NeighborCount => Neighbors.Count;
        public Vertex<T> Founder;
        public bool Visited = false;
        public float CumulativeDistance = float.PositiveInfinity;
        public float FinalDistance = float.PositiveInfinity;
        public Vertex(T value) 
        {
            Neighbors = new List<Edge<T>>();
            Value = value;
            Founder = null;
        }
        public override string ToString()
        {
            return Value.ToString();
        }
        public int CompareTo(Vertex<T> other)
        {
            if (other.CumulativeDistance.Equals(CumulativeDistance))
            {
                return 0;
            }
            if (other.CumulativeDistance > CumulativeDistance)
            {
                return 1;
            }
            if (other.CumulativeDistance < CumulativeDistance)
            {
                return -1;
            }
            //Flipped CompareTo because Heap is Max-Heap
            return 0;
        }
    }
}
