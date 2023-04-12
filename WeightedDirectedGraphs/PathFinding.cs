using Heap_Tree;

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;

namespace WeightedDirectedGraphs
{
    using Heuristic = Func<Point, Point, float>;

    public static class PathFinding
    {

        public enum Result
        {
            Found,
            NotFound,
            InvalidPos
        }

        static Heuristic[] heuristicArray = new Heuristic[] { Manhattan, Diagonal, Euclidean, Identity };

        public static Func<Point, Point, float> Heuristics(HeuristicsChoices heuristicsChoices)
        {
            return heuristicArray[(int)heuristicsChoices];
        }
        public static float Identity(Point start, Point end)
        {
            //Dijkstra
            return 0;
        }
        public static float Manhattan(Point start, Point end)
        {
            float dx = Math.Abs(start.X - end.X);
            float dy = Math.Abs(start.Y - end.Y);
            return 1 * (dx + dy);
        }
        static float Diagonal(Point start, Point end)
        {
            float dx = Math.Abs(start.X - end.X);
            float dy = Math.Abs(start.Y - end.Y);
            return 1 * (dx + dy) + (1 - 2 * 1) * Math.Min(dx, dy);
        }
        static float Euclidean(Point start, Point end)
        {
            float dx = Math.Abs(start.X - end.X);
            float dy = Math.Abs(start.Y - end.Y);
            return 1 * (float)Math.Sqrt(dx * dx + dy * dy);
        }

        public static HashSet<Edge<T>> GetCycle<T>(Graph<T> graph)
        {
            Heap<Vertex<T>> queue = new Heap<Vertex<T>>(5);

            HashSet<Edge<T>> visited = new HashSet<Edge<T>>();

            for (int j = 0; j < graph.VertexCount; j++)
            {
                foreach (var vert in graph.Vertices)
                {
                    vert.CumulativeDistance = float.PositiveInfinity;
                    vert.Visited = false;
                }
                graph.Vertices[j].CumulativeDistance = 0;
                queue.Push(graph.Vertices[j]);

                while (queue.Count > 0)
                {
                    Vertex<T> vertex = queue.Pop();
                    vertex.Visited = true;

                    for (int i = 0; i < vertex.NeighborCount; i++)
                    {
                        float tentDist = vertex.CumulativeDistance + vertex.Neighbors[i].Weight;
                        if (vertex.Neighbors[i].EndingPoint.Visited != true)
                        {
                            if (tentDist.CompareTo(vertex.Neighbors[i].EndingPoint.CumulativeDistance) < 0)
                            {
                                bool pushed = false;
                                if (float.IsPositiveInfinity(vertex.Neighbors[i].EndingPoint.CumulativeDistance))
                                {
                                    queue.Push(vertex.Neighbors[i].EndingPoint);
                                    pushed= true;
                                }
                                else
                                {
                                    queue.HeapifyUp(queue.Find(vertex.Neighbors[i].EndingPoint));
                                }
                                vertex.Neighbors[i].EndingPoint.CumulativeDistance = tentDist;

                                vertex.Neighbors[i].EndingPoint.Founder = vertex;
                            }
                        }
                        else
                        {
                            if (vertex.Neighbors[i].EndingPoint.CumulativeDistance > tentDist)
                            {
                                if (!visited.Contains(vertex.Neighbors[i]))
                                {
                                    visited.Add(vertex.Neighbors[i]);
                                }
                            }
                        }
                    }
                }
            }


  

            //for (int j = 0; j < graph.VertexCount; j++)
            //{
            //    Vertex<Point> vertex = graph.Vertices[j];
            //    for (int i = 0; i < vertex.NeighborCount; i++)
            //    {
            //        float tentDist = vertex.Neighbors[i].Weight + vertex.CumulativeDistance;

            //        if (tentDist.CompareTo(vertex.Neighbors[i].EndingPoint.CumulativeDistance) < 0)
            //        {
            //            visited.Add(vertex.Neighbors[i]);
            //        }
            //    }
            //}

            return visited;
        }

        public static Result Astar(out List<AStarInfo> data, out List<Vertex<Point>> path, Vertex<Point> Start, Vertex<Point> End, Heuristic heuristic)
        {
            data = new List<AStarInfo>();
            if (End == null || Start == null)
            {
                path = null;
                return Result.InvalidPos;
            }
            Start.CumulativeDistance = 0;

            Start.FinalDistance = heuristic(Start.Value, End.Value);

            Heap<Vertex<Point>> queue = new Heap<Vertex<Point>>(5);
            Start.CumulativeDistance = 0;

            Start.FinalDistance = heuristic(Start.Value, End.Value);

            queue.Push(Start);

            path = new List<Vertex<Point>>();


            while (End.Visited == false)
            {
                if (queue.Count == 0)
                {
                    return Result.NotFound;
                }

                Vertex<Point> vertex = queue.Pop();

                data.Add(new AStarInfo(ColorToBrush.Visited, vertex.Value));

                for (int i = 0; i < vertex.NeighborCount; i++)
                {
                    if (vertex.Neighbors[i].EndingPoint.Visited != true)
                    {
                        float tentDist = vertex.CumulativeDistance + vertex.Neighbors[i].Weight;

                        if (tentDist.CompareTo(vertex.Neighbors[i].EndingPoint.CumulativeDistance) < 0)
                        {
                            vertex.Neighbors[i].EndingPoint.CumulativeDistance = tentDist;

                            vertex.Neighbors[i].EndingPoint.FinalDistance = tentDist + heuristic(vertex.Neighbors[i].EndingPoint.Value, End.Value);

                            int temp = queue.Find(vertex.Neighbors[i].EndingPoint);

                            if (temp == -1)
                            {
                                queue.Push(vertex.Neighbors[i].EndingPoint);
                                data.Add(new AStarInfo(ColorToBrush.Queued, vertex.Neighbors[i].EndingPoint.Value));
                            }
                            else
                            {
                                queue.HeapifyUp(temp);
                            }

                            vertex.Neighbors[i].EndingPoint.Founder = vertex;

                        }
                    }
                }

                vertex.Visited = true;
            }

            if (End.Visited == true)
            {
                Vertex<Point> finder = End;

                while (finder.Founder != null)
                {
                    path.Add(finder);

                    finder = finder.Founder;
                }
                path.Add(finder);
                path.Reverse();
                for (int i = 0; i < path.Count; i++)
                {
                    data.Add(new AStarInfo(ColorToBrush.FinalPath, path[i].Value));
                }
            }

            return Result.Found;
        }

        public static Result AStar(out List<AStarInfo> data, out List<Vertex<Point>> path, Graph<Point> graph, Point start, Point end, Heuristic heuristic)
        {
            Vertex<Point> Start = graph.Search(start);
            Vertex<Point> End = graph.Search(end);
            return Astar(out data, out path, Start, End, heuristic);
        }


    }
}
