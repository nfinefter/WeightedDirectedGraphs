﻿using Heap_Tree;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace WeightedDirectedGraphs
{
    class Graph<T> where T : IComparable<T>
    {
        
        private List<Vertex<T>> vertices = new List<Vertex<T>>();

        public IReadOnlyList<Vertex<T>> Vertices => vertices;
        public IReadOnlyList<Edge<T>> Edges
        {
            get
            {
                List<Edge<T>> edges = new List<Edge<T>>();

                for (int i = 0; i < Count; i++)
                {
                    for (int j = 0; j < vertices[i].NeighborCount; j++)
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
                    for (int i = 0; i < item.NeighborCount; i++)
                    {

                        if (item.Neighbors[i].EndingPoint.Equals(vertex))
                        {
                            RemoveEdge(item, vertex);
                        }
                    }
                }
                vertices.Remove(vertex);
                return true;
            }
            return false;
        }
        public bool AddEdge(Vertex<T> a, Vertex<T> b, float distance)
        {
            Edge<T> newEdge = new Edge<T>(a, b, distance);

            if (a != null && b != null && vertices.Contains(a) && vertices.Contains(b) && !a.Neighbors.Contains(newEdge))
            {
                a.Neighbors.Add(newEdge);
                return true;
            }
            return false;
        }
        public bool RemoveEdge(Vertex<T> a, Vertex<T> b)
        {
            if (a == null || b == null)
            {
                return false;
            }
            foreach (Edge<T> edge in a.Neighbors)
            {
                if (edge.EndingPoint.Equals(b))
                {
                    a.Neighbors.Remove(edge);
                    return true;
                }
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


            if (a == null || b == null)
            {
                return null;
            }
            foreach (Edge<T> edge in a.Neighbors)
            {
                if (edge.EndingPoint.Equals(b))
                {
                    return edge;
                }
            }


            return null;
        }

        public List<Vertex<T>> BFS(Vertex<T> start, Vertex<T> end)
        {
            List<Vertex<T>> path = new List<Vertex<T>>();

            Vertex<T> temp = start;
            Queue<Vertex<T>> vertices = new Queue<Vertex<T>>();

            vertices.Enqueue(start);

            while (!vertices.Contains(end) && vertices.Count > 0)
            {
                temp = vertices.Dequeue();
                for (int i = 0; i < temp.NeighborCount; i++)
                {
                    vertices.Enqueue(temp.Neighbors[i].EndingPoint);
                    temp.Neighbors[i].EndingPoint.Parent = temp;
                }
            }
            temp = end;
            while (temp != null && !path.Contains(temp))
            {
                path.Add(temp);
                temp = temp.Parent;
            }

            path.Reverse();

            return path;
        }
        public List<Vertex<T>> DepthFirstSearch(Vertex<T> start, Vertex<T> end) // T[]
        {
            List<Vertex<T>> vertices = new List<Vertex<T>>();
            vertices.Add(start);

            Vertex<T> cursor;

            Dictionary<Vertex<T>, Vertex<T>> Founders = new Dictionary<Vertex<T>, Vertex<T>>();

            Founders.Add(start, null);

            while (vertices.Count > 0)
            {
                cursor = vertices[vertices.Count - 1];

                vertices.RemoveAt(vertices.Count - 1);

                if (cursor == end)
                {
                    return Path(cursor, Founders, start);
                }

                foreach (Edge<T> Neighbor in cursor.Neighbors)
                {
                    //if (!Founders.ContainsKey(Neighbor.EndingPoint))
                    //{
                    //    vertices.Push(Neighbor.EndingPoint);
                    //    Founders.Add(Neighbor.EndingPoint, cursor);
                    //}
                    if (!Founders.ContainsKey(Neighbor.EndingPoint))
                    {                        
                        vertices.Add(Neighbor.EndingPoint);
                        Founders.Add(Neighbor.EndingPoint, cursor);
                    }
                    else if (vertices.Contains(Neighbor.EndingPoint))
                    {
                        vertices.Remove(Neighbor.EndingPoint);
                        vertices.Add(Neighbor.EndingPoint);
                        Founders[Neighbor.EndingPoint] = cursor;
                    }
                }
            }
            return new List<Vertex<T>>();
        }
        public List<Vertex<T>> DepthFirstSearch(T start, T end)
        {
            return DepthFirstSearch(Search(start), Search(end));
        }

        public List<Vertex<T>> Path(Vertex<T> cursor, Dictionary<Vertex<T>, Vertex<T>> Founders, Vertex<T> start)
        {
            List<Vertex<T>> path = new List<Vertex<T>>();

            while (cursor != null)
            {

                path.Add(cursor);

                cursor = Founders[cursor];


            }

            path.Reverse();

            return path;

        }
        public List<Vertex<T>> Djikstra(Graph<T> graph, Vertex<T> start, Vertex<T> end)
        {
            Heap<Vertex<T>> queue = new Heap<Vertex<T>>(5);

            List<Vertex<T>> path = new List<Vertex<T>>();

            Vertex<T> temp = start;

            temp.Distance = 0;
                
            queue.Push(temp);

            Vertex<T> vertex;

            while (end.Visited == false)
            {
                vertex = queue.Pop();

                //Crashes because distance is infiniy?
                //Make the distances 0?
                

                for (int i = 0; i < vertex.NeighborCount; i++)
                {  
                    if (vertex.Neighbors[i].EndingPoint.Visited == true)
                    {
                        float tentDist = vertex.Distance + vertex.Neighbors[i].Weight;
                        if (tentDist.CompareTo(vertex.Distance + vertex.Neighbors[i].Weight) < 0)
                        {
                            vertex.Neighbors[i].EndingPoint.Distance = tentDist;
                            if (vertex.Neighbors[i].EndingPoint.Visited != true)
                            {
                                vertex.Neighbors[i].EndingPoint.Parent = vertex;
                            }
                        } 
                    }
                }

                for (int i = 0; i < vertex.NeighborCount; i++)
                {
                    if (vertex.Neighbors[i].EndingPoint.Visited == false || !queue.Contains(vertex.Neighbors[i].EndingPoint))
                    {
                        queue.Push(vertex.Neighbors[i].EndingPoint);
                    }
                }
                vertex.Visited = true;
                
            }

            if (end.Visited == true)
            {
                Vertex<T> finder = end;

                while (finder.Parent != null)
                {
                    path.Add(finder);
                    finder = finder.Parent;
                }
            }

            return path;
        }
    }
}
