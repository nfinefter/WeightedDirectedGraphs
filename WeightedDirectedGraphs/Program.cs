using System;
using System.Collections.Generic;

namespace WeightedDirectedGraphs
{
    class Program
    {
        static void Main(string[] args)
        {
            Graph<string> graph = new Graph<string>();

            Vertex<string> vertex = new Vertex<string>("LAX");

            graph.AddVertex(vertex);

            Vertex<string> vertex1 = new Vertex<string>("AUS");
            graph.AddVertex(vertex1);
            Vertex<string> vertex2 = new Vertex<string>("SEA");
            graph.AddVertex(vertex2);
            Vertex<string> vertex3 = new Vertex<string>("LOG");
            graph.AddVertex(vertex3);
            Vertex<string> vertex4 = new Vertex<string>("JFK");
            graph.AddVertex(vertex4);
            Vertex<string> vertex5 = new Vertex<string>("ABA");
            graph.AddVertex(vertex5);
            

            graph.AddEdge(vertex1, vertex2, 5);
            graph.AddEdge(vertex2, vertex4, 5);
            graph.AddEdge(vertex3, vertex5, 5);
            graph.AddEdge(vertex2, vertex1, 5);
            //graph.AddEdge(vertex5, vertex1, 5);

            //Edge<string> temp = graph.GetEdge(vertex1, vertex4);

            List<Vertex<string>> items = graph.BFS(vertex1, vertex4);

            for (int i = 0; i < items.Count; i++)
            {
                Console.WriteLine(items[i].Value);
            }
            

            graph.RemoveVertex(vertex3);
        }
    }
}
