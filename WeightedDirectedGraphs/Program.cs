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

            Vertex<Point> AUS = new Vertex<Point>(new Point(5, 4));
            graph.AddVertex(AUS);
            Vertex<Point> SEA = new Vertex<Point>(new Point(7, 22));
            graph.AddVertex(SEA);
            Vertex<Point> LOG = new Vertex<Point>(new Point(22, 7));
            graph.AddVertex(LOG);
            Vertex<Point> JFK = new Vertex<Point>(new Point(16, 5));
            graph.AddVertex(JFK);
            Vertex<Point> bestband = new Vertex<Point>(new Point(25, 12));
            graph.AddVertex(bestband);

            graph.AddEdge(AUS, SEA, 5);
            graph.AddEdge(AUS, bestband, 1);
            graph.AddEdge(bestband, AUS, 1);
            graph.AddEdge(bestband, SEA, 0);
           
            graph.AddEdge(SEA, JFK, 5);
            graph.AddEdge(LOG, bestband, 5);
            graph.AddEdge(SEA, AUS, 5);

            Console.WriteLine("0: Manhattan, 1: Diagonal, 2: Euclidean");
            int heuristicsChoice = int.Parse(Console.ReadLine());

            Console.WriteLine("Give a scale");
            int scale = int.Parse(Console.ReadLine());

            Console.WriteLine("Give a scale");
            int scale2 = int.Parse(Console.ReadLine());

            List<Vertex<Point>> items = PathFinding.AStar(graph, AUS.Value, JFK.Value, (HeuristicsChoices)heuristicsChoice, scale, scale2);
            
            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i].Value);
            }

        }
    }
}
