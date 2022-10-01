using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;


namespace WeightedDirectedGraphs
{
    class Program
    {
        static (Point, Point) PointsParse(string num)
        {
            string[] strings = num.Split(',');
            if (strings.Length != 4)
            {
                throw new ArgumentException("Invalid number of coordinates given.");
            }

            return new ValueTuple<Point, Point>(new Point(int.Parse(strings[0]), int.Parse(strings[1])), new Point(int.Parse(strings[2]), int.Parse(strings[3])));

        }

        static void Main(string[] args)
        {            
            Graph<Point> graph = new Graph<Point>();

            //Vertex<Point> AUS = new Vertex<Point>(new Point(5, 4));
            //graph.AddVertex(AUS);
            //Vertex<Point> SEA = new Vertex<Point>(new Point(7, 22));
            //graph.AddVertex(SEA);
            //Vertex<Point> LOG = new Vertex<Point>(new Point(22, 7));
            //graph.AddVertex(LOG);
            //Vertex<Point> JFK = new Vertex<Point>(new Point(16, 5));
            //graph.AddVertex(JFK);
            //Vertex<Point> bestband = new Vertex<Point>(new Point(25, 12));
            //graph.AddVertex(bestband);

            //graph.AddEdge(AUS, SEA, 5);
            //graph.AddEdge(AUS, bestband, 1);
            //graph.AddEdge(bestband, AUS, 1);
            //graph.AddEdge(bestband, SEA, 0);

            //graph.AddEdge(SEA, JFK, 5);
            //graph.AddEdge(LOG, bestband, 5);
            //graph.AddEdge(SEA, AUS, 5);

            Random rand = new Random();



            Console.WriteLine("How big should the graph be");
            int size = int.Parse(Console.ReadLine());

            for (int x = 0; x < size; x++)
            {
                for (int y = 0; y < size; y++)
                {
                    Vertex<Point> temp = new Vertex<Point>(new Point(x, y));
                    graph.AddVertex(temp);

                    if (x >= 0 && y >= 0)
                    {
                            Vertex<Point> prevX = graph.Search(new Point(x - 1, y));
                            graph.AddEdge(prevX, temp, 1);
                            graph.AddEdge(temp, prevX, 1);    

                            Vertex<Point> prevY = graph.Search(new Point(x, y - 1));
                            graph.AddEdge(prevY, temp, 1);
                            graph.AddEdge(temp, prevY, 1);       
                    }
                }
            }

            int heuristicsChoice = -1;

            while (heuristicsChoice < 0 || heuristicsChoice > 2)
            {
                Console.WriteLine("0: Manhattan, 1: Diagonal, 2: Euclidean");
                heuristicsChoice = int.Parse(Console.ReadLine());
            }

            Console.WriteLine("Give me two points each point separated by commas (X1, Y1, X2, Y2)");
            string pointInput = Console.ReadLine();

            (Point, Point) points = PointsParse(pointInput);

            PathFinding.Result result = PathFinding.AStar(out var data, out var items, graph, points.Item1, points.Item2, PathFinding.Heuristics((HeuristicsChoices)heuristicsChoice));

            Console.WriteLine(result.ToString());

            if (result == PathFinding.Result.Found)
            {
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine(items[i].Value);
                }
            }

        }
    }
}
