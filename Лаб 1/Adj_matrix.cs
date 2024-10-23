using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_1
{
    public class Adj_matrix
    {
        private int[,] matrix;
        private int verticesCount;
        private bool isDirected;
        private string[] verteceis;

        public Adj_matrix(int vertices, bool isDirected, string[] verteceis)
        {
            this.isDirected = isDirected;
            verticesCount = vertices;
            matrix = new int[vertices, vertices];
            this.verteceis = verteceis;
        }

        public void AddEdge(int source, int destination)
        {
            matrix[source, destination] = 1;
            if (!isDirected)
            {
                matrix[destination, source] = 1;
            }
        }

        public Inc_matrix ToIncMatrix()
        {
            int edgesCount = 0;
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = (isDirected ? 0 : i); j < verticesCount; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        edgesCount++;
                    }
                }
            }
            Inc_matrix incMatrix = new Inc_matrix(verticesCount, edgesCount, isDirected, verteceis);
            int edgeIndex = 0;
            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = (isDirected ? 0 : i); j < verticesCount; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        incMatrix.AddEdge(i, j);
                        edgeIndex++;
                    }
                }
            }
            return incMatrix;
        }

        public adj_List ToAdjList()
        {
            var adjList = new adj_List(verticesCount, isDirected, verteceis);

            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = 0; j < verticesCount; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        adjList.AddEdge(i, j);
                    }
                }
            }
            return adjList;
        }

        public Edge_List ToEdgeList()
        {
            var edgeList = new Edge_List(isDirected, verteceis);

            for (int i = 0; i < verticesCount; i++)
            {
                for (int j = (isDirected ? 0 : i); j < verticesCount; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        edgeList.AddEdge(i, j);
                    }
                }
            }
            return edgeList;
        }

        public void SetMatrix(int[,] newMatrix)
        {
            matrix = newMatrix;
        }

        public void Print()
        {
            // Виведення заголовка з назвами вершин
            Console.Write("   ");  // Зміщення для назв вершин
            for (int i = 0; i < verticesCount; i++)
            {
                Console.Write($"{verteceis[i]} ".PadRight(4));
            }
            Console.WriteLine();

            // Виведення матриці суміжності з назвами вершин
            for (int i = 0; i < verticesCount; i++)
            {
                Console.Write(verteceis[i] + "  ");  // Виведення назви вершини
                for (int j = 0; j < verticesCount; j++)
                {
                    Console.Write(matrix[i, j].ToString().PadRight(4));
                }
                Console.WriteLine();
            }
        }
    }
}
