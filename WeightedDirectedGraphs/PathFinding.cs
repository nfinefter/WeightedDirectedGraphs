using Heap_Tree;
using System;
using System.Collections.Generic;
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

        static Heuristic[] heuristicArray = new Heuristic[] { Manhattan, Diagonal, Euclidean};

        public static Func<Point, Point, float> Heuristics(HeuristicsChoices heuristicsChoices)
        {
            return heuristicArray[(int)heuristicsChoices];
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
        public static Result AStar(out List<Vertex<Point>> path, Graph<Point> graph, Point start, Point end, Heuristic heuristic)
        {
            
            Heap<Vertex<Point>> queue = new Heap<Vertex<Point>>(5);

            Vertex<Point> Start = graph.Search(start);
            Vertex<Point> End = graph.Search(end);

            if (End == null || Start == null)
            {
                //Invalid Pos
                path = null;
                return Result.InvalidPos;
            }

            Start.CumulativeDistance = 0;

            Start.FinalDistance = heuristic(start, end);

            queue.Push(Start);
            path = new List<Vertex<Point>>();

            while (End.Visited == false)
            {
                if (queue.Count == 0)
                {
                    //Not Found
                    return Result.NotFound;
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

                            vertex.Neighbors[i].EndingPoint.FinalDistance = tentDist + heuristic(start, end);

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

            //Found
            return Result.Found;
        }

      
    }
}
