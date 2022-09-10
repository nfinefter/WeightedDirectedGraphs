using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;

namespace WeightedDirectedGraphs
{
    class Program
    {
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

            for (int x = 0; x < 5; x++)
            {
                for (int y = 0; y < 5; y++)
                {
                    Vertex<Point> temp = new Vertex<Point>(new Point(x, y));
                    graph.AddVertex(temp);

                    if (x >= 0 && y >= 0)
                    {
                     
                            Vertex<Point> prevX = graph.Search(new Point(x - 1, y));
                            graph.AddEdge(prevX, temp, 1);

                            Vertex<Point> prevY = graph.Search(new Point(x, y - 1));
                            graph.AddEdge(prevY, temp, 1);

                    }
                }
            }

            Console.WriteLine("0: Manhattan, 1: Diagonal, 2: Euclidean");
            int heuristicsChoice = int.Parse(Console.ReadLine());

            List<Vertex<Point>> items = PathFinding.AStar(graph, new Point(3, 4), new Point(0, 0), (HeuristicsChoices)heuristicsChoice);
            //Not able to search backwards from Example: (3,4) to (0,0)

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i].Value);
            }

        }
    }
}
