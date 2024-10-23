using System.Collections.Generic;
using System;
using Лаб_1;

public class Inc_matrix
{
    private int[,] matrix;
    private int verticesCount;
    private int edgesCount;
    private bool isDirected;
    private string[] verteceis;
    private List<string> edges = new List<string>();

    public Inc_matrix(int vertices, int edges, bool isDirected, string[] verteceis)
    {
        this.isDirected = isDirected;
        verticesCount = vertices;
        edgesCount = 0; // Стартуємо з 0 ребер
        matrix = new int[vertices, edges];
        this.verteceis = verteceis;
    }

    public void AddEdge(int source, int destination)
    {
        if (edgesCount >= matrix.GetLength(1))
        {
            Console.WriteLine("Неможливо додати більше ребер, ніж дозволено.");
            return;
        }

        if (isDirected)
        {
            matrix[source, edgesCount] = 1; // Вихід з вершини
            matrix[destination, edgesCount] = -1; // Вхід у вершину
        }
        else
        {
            matrix[source, edgesCount] = 1; // Вершина інцидентна ребру
            matrix[destination, edgesCount] = 1; // Вершина інцидентна ребру
        }
        edgesCount++;
        edges.Add($"{verteceis[source]}{verteceis[destination]}");
    }

    public void Print()
    {
        // Виведення заголовка з назвами ребер
        Console.Write("   ");  // Зміщення для назв ребер
        for (int j = 0; j < edges.Count; j++)
        {
            Console.Write($"{edges[j]} ".PadRight(4));
        }
        Console.WriteLine();

        // Виведення матриці інцидентності з назвами вершин
        for (int i = 0; i < verticesCount; i++)
        {
            Console.Write(verteceis[i] + "  ");  // Виведення назви вершини
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                Console.Write(matrix[i, j].ToString().PadRight(4));
            }
            Console.WriteLine();
        }
    }

    // Конвертація в список ребер
    public Edge_List ToEdgeList()
    {
        var edgeList = new Edge_List(isDirected, verteceis);

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int source = -1;
            int destination = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == 1 && source == -1)
                {
                    source = i;
                }
                else if ((matrix[i, j] == -1 && isDirected) || (matrix[i, j] == 1 && !isDirected && source != i))
                {
                    destination = i;
                }
            }

            if (source != -1 && destination != -1)
            {
                edgeList.AddEdge(source, destination);
            }
        }
        return edgeList;
    }

    // Конвертація в матрицю суміжності
    public Adj_matrix ToAdjMatrix()
    {
        int[,] adjMatrix = new int[verticesCount, verticesCount];

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int source = -1;
            int destination = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == 1 && source == -1)
                {
                    source = i;
                }
                else if ((matrix[i, j] == -1 && isDirected) || (matrix[i, j] == 1 && !isDirected && source != i))
                {
                    destination = i;
                }
            }

            if (source != -1 && destination != -1)
            {
                adjMatrix[source, destination] = 1;
                if (!isDirected)
                {
                    adjMatrix[destination, source] = 1;
                }
            }
        }

        var adjMatrixClass = new Adj_matrix(verticesCount, isDirected, verteceis);
        adjMatrixClass.SetMatrix(adjMatrix);
        return adjMatrixClass;
    }

    // Конвертація в список суміжності
    public adj_List ToAdjList()
    {
        var adjList = new adj_List(verticesCount, isDirected, verteceis);

        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            int source = -1;
            int destination = -1;

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                if (matrix[i, j] == 1 && source == -1)
                {
                    source = i;
                }
                else if ((matrix[i, j] == -1 && isDirected) || (matrix[i, j] == 1 && !isDirected && source != i))
                {
                    destination = i;
                }
            }

            if (source != -1 && destination != -1)
            {
                adjList.AddEdge(source, destination);

                if (!isDirected)
                {
                    adjList.AddEdge(destination, source); // Додаємо ребро в обидві сторони для ненаправлених графів
                }
            }
        }

        return adjList;
    }
}
