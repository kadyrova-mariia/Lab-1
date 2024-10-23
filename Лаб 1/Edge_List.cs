using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_1
{
    public class Edge_List
    {
        private List<(int, int)> edges;
        private bool isDirected;
        private string[] verteceis;


        public Edge_List(bool isDirected, string[] verteceis)
        {
            this.isDirected = isDirected;
            edges = new List<(int, int)>();
            this.verteceis = verteceis;

        }

        public void AddEdge(int source, int destination)
        {
            edges.Add((source, destination));
            if (!isDirected)
            {
                edges.Add((destination, source));
            }
        }
        public void PrintEdges()
        {
            Console.WriteLine("Список ребер:");
            foreach (var edge in edges)
            {
                Console.WriteLine($"{verteceis[edge.Item1]} -> {verteceis[edge.Item2]}");
                if (!isDirected)
                {
                    Console.WriteLine($"{verteceis[edge.Item2]} -> {verteceis[edge.Item1]}");
                }
            }
        }
    }
}
