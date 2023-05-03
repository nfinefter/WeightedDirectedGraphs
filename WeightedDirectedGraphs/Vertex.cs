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
        public Vertex<T> Founder = null;
        bool visited = false;
        public bool Visited
        {
            get => visited; set
            {
                visited = value;
                if (visited == false && !float.IsInfinity(CumulativeDistance))
                {
                    ;
                }
            }
        }
        private float cumulativeDistance = float.PositiveInfinity;
        public float CumulativeDistance
        {
            get => cumulativeDistance; set
            {
                //if (value == 1048)
                //    ;
                cumulativeDistance = value;
            }
        }
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

            if (other.FinalDistance.Equals(FinalDistance))
            {
                return 0;
            }
            else if (other.FinalDistance > FinalDistance)
            {
                return 1;
            }

            return -1;

            //Flipped CompareTo because Heap is Max-Heap
        }
    }
}
