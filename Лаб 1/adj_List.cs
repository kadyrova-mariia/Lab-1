using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_1
{
    public class adj_List
    {
        private List<List<int>> adjacencyList;
        private bool isDirected;
        private string[] verteceis;
        private int verticesCount;



        public adj_List(int vertices, bool isDirected, string[] verteceis)
        {
            verticesCount = vertices;
            this.isDirected = isDirected;
            adjacencyList = new List<List<int>>(vertices);
            for (int i = 0; i < vertices; i++)
            {
                adjacencyList.Add(new List<int>());
            }
            this.verteceis = verteceis;
        }

        public void AddEdge(int source, int destination)
        {
            adjacencyList[source].Add(destination);
            if (!isDirected)
            {
                adjacencyList[destination].Add(source);
            }
        }

        public void PrintAdjacencyList()
        {
            Console.WriteLine("Список суміжності:");
            for (int i = 0; i < verticesCount; i++)
            {
                Console.Write(verteceis[i] + ": ");
                foreach (var neighbor in adjacencyList[i])
                {
                    Console.Write(verteceis[neighbor] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
