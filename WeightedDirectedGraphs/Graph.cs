using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraphs
{
    class Graph<T> where T : IComparable<T>
    {
        private List<Vertex<T>> vertices;

        public IReadOnlyList<Vertex<T>> Vertices => vertices;
        public IReadOnlyList<Edge<T>> Edges
        {
            get
            {
                List<Edge<T>> edges = new List<Edge<T>>();

                for (int i = 0; i < Count; i++)
                {
                    for (int j = 0; j < vertices.Count; j++)
                    {
                        edges.Add(vertices[i].Neighbors[j]);
                    }
                }

                return edges;
            }
        }

        public int Count
        {
            get { return vertices.Count; }
        }

        public int VertexCount => vertices.Count;

        public Graph()
        {

        }
        public void AddVertex(Vertex<T> vertex)
        {
            if (vertex != null || vertex.NeighborCount != 0 || !vertices.Contains(vertex))
            {
                vertices.Add(vertex);
            }
        }
        public bool RemoveVertex(Vertex<T> vertex)
        {
            if (vertices.Contains(vertex))
            {
                foreach (var item in vertices)
                {

                    for (int i = 0; i < vertices.Count; i++)
                    {
                        if (item.Neighbors[i].EndingPoint.Equals(vertex))
                        {
                            RemoveEdge(item, vertex);
                        }
                }
                }
                return true;
            }
            return false;
        }
        public bool AddEdge(Vertex<T> a, Vertex<T> b, float distance)
        {
            //add check if the same edge doesnt exist
            if (a != null && b != null && !vertices.Contains(a) && !vertices.Contains(b))
            {
                //Add edge
                return true;
            }
            return false;
        }
        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if (a != null && b != null)
            {
                //check that the edge with starting point a and ending point b exists to be able to remove the edge between the two vertices
                return true;
            }
            return false;
        }
        public Vertex<T> Search(T value)
        {
            int count = -1;
            for (int i = 0; i < vertices.Count; i++)
            {
                if (value.CompareTo(vertices[i].Value) == 0)
                {
                    count = i;
                    break;
                }
            }
            if (count == -1)
            {
                return null;
            }
            return vertices[count];
        }
        public Edge<T> GetEdge(Vertex<T> a, Vertex<T> b)
        {
            if (a != null && b != null)
            {

            }
            return null;
        }
    }
}
