using System;
using System.Collections.Generic;

namespace WeightedDirectedGraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new Graph<string>();

            Vertex<string> LAX = new Vertex<string>("LAX");

            graph.AddVertex(LAX);

            Vertex<string> AUS = new Vertex<string>("AUS");
            graph.AddVertex(AUS);
            Vertex<string> SEA = new Vertex<string>("SEA");
            graph.AddVertex(SEA);
            Vertex<string> LOG = new Vertex<string>("LOG");
            graph.AddVertex(LOG);
            Vertex<string> JFK = new Vertex<string>("JFK");
            graph.AddVertex(JFK);
            Vertex<string> bestband = new Vertex<string>("ABA");
            graph.AddVertex(bestband);

            graph.AddEdge(AUS, SEA, 5);
            graph.AddEdge(AUS, bestband, 1000);
            graph.AddEdge(bestband, AUS, 100);
            graph.AddEdge(bestband, SEA, 2);
           
            graph.AddEdge(SEA, JFK, 5);
            graph.AddEdge(LOG, bestband, 5);
            graph.AddEdge(SEA, AUS, 5);
                
            List<Vertex<string>> items = graph.DepthFirstSearch(AUS, JFK);

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i].Value);
            }

           

        }
    }
}
