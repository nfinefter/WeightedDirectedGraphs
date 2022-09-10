using Heap_Tree;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace WeightedDirectedGraphs
{
    public static class PathFinding
    {
        static float Heuristics(Point start, Point end, HeuristicsChoices heuristicsChoices)
        {
            if (heuristicsChoices == HeuristicsChoices.Manhattan)
            {
                return Manhattan(start, end);
            }
            if (heuristicsChoices == HeuristicsChoices.Diagonal)
            {
                return Diagonal(start, end);
            }
            if (heuristicsChoices == HeuristicsChoices.Euclidean)
            {
                return Euclidean(start, end);
            }

            throw new Exception("Choice of heuristics algorithm not given!");
        }

        static float Manhattan(Point start, Point end)
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

        public static List<Vertex<Point>> AStar(Graph<Point> graph, Point start, Point end, HeuristicsChoices heuristicsChoice)
        {
            List<Vertex<Point>> path = new List<Vertex<Point>>();
            Heap<Vertex<Point>> queue = new Heap<Vertex<Point>>(5);

            Vertex<Point> Start = graph.Search(start);
            Vertex<Point> End = graph.Search(end);

            Start.CumulativeDistance = 0;

            Start.FinalDistance = Heuristics(start, end, heuristicsChoice);

            queue.Push(Start);

            while (End.Visited == false)
            {
                if (queue.Count == 0)
                {
                    return path;
                }

                Vertex<Point> vertex = queue.Pop();

                for (int i = 0; i < vertex.NeighborCount; i++)
                {
                    if (vertex.Neighbors[i].EndingPoint.Visited != true)
                    {
                        float tentDist = vertex.CumulativeDistance + vertex.Neighbors[i].Weight;

                        if (tentDist.CompareTo(vertex.Neighbors[i].EndingPoint.CumulativeDistance) < 0)
                        {
                            vertex.Neighbors[i].EndingPoint.CumulativeDistance = tentDist;

                            vertex.Neighbors[i].EndingPoint.FinalDistance = tentDist + Heuristics(vertex.Neighbors[i].EndingPoint.Value, end, heuristicsChoice);

                            int temp = queue.Find(vertex.Neighbors[i].EndingPoint);

                            if (temp == -1)
                            {
                                queue.Push(vertex.Neighbors[i].EndingPoint);
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

                while (finder != null)
                {
                    path.Add(finder);
                    finder = finder.Founder;
                }
                path.Reverse();
            }

            return path;
        }
    }
}
