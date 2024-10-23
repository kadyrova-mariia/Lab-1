using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Лаб_1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.Clear();
            Console.WriteLine("Виберіть метод збереження\n" +
                          "1. Матриця суміжності\n" +
                          "2. Список суміжності\n" +
                          "3. Матриця інцидентності\n" +
                          "4. Список ребер");
            int storageType = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Виберіть тип графа\n" +
                          "1. Не направлений\n" +
                          "2. Направлений");
            int graphType = int.Parse(Console.ReadLine());
            bool isDirected = Convert.ToBoolean(graphType - 1);
            Console.Clear();
            adj_List adj_list = create_Adj_List(isDirected);
            Edge_List edge_list  = create_Edge_List(isDirected);
            Adj_matrix adj_mat  = create_adj_Matrix(isDirected);
            Inc_matrix inc_mat = create_inc_Matrix(isDirected);

            switch (storageType)
            {
                case 1:
                    adj_mat.Print();
                    break;
                case 2:
                    adj_list.PrintAdjacencyList();
                    break;
                case 3:
                    inc_mat.Print();
                    break;
                case 4:
                    edge_list.PrintEdges();
                    break;
            }
            Console.ReadKey();
            Console.Clear();
            Console.Write("Які перетворення ви бажаєте\n" +
                "1. Матриці суміжності\n" +
                "2. Матриці інцидентності\n" +
                "0. Жодних");
            int mutation = int.Parse(Console.ReadLine());
            Console.Clear();
            
            switch(mutation)
            {
                case 1:
                    adj_mat.ToAdjList().PrintAdjacencyList();
                    adj_mat.ToEdgeList().PrintEdges();
                    adj_mat.ToIncMatrix().Print();
                    break;
                case 2:
                    inc_mat.ToAdjList().PrintAdjacencyList();
                    inc_mat.ToEdgeList().PrintEdges();
                    inc_mat.ToAdjMatrix().Print();
                    break;
                case 0:
                    Main(args);
                    break;
            }
            Console.ReadKey();
            Main(args);

        }
        static adj_List create_Adj_List (bool isDirected)
        {
            int[,] edge_list = select_edge_list(isDirected);
            string[] ver = getVertecies();
            adj_List adj_list  = new adj_List(ver.GetLength(0), isDirected, ver);
            for (int i = 0; i < edge_list.GetLength(0); i++)
            {
                adj_list.AddEdge(edge_list[i, 0], edge_list[i, 1]);
            }
            return adj_list;

        }
        static Edge_List create_Edge_List(bool isDirected)
        {
            string[] ver = getVertecies();
            int[,] list = select_edge_list(isDirected);
            Edge_List edge_list = new Edge_List(isDirected, ver);
            for (int i = 0; i < list.GetLength(0); i++)
            {
                edge_list.AddEdge(list[i, 0], list[i, 1]);
            }
            return edge_list;
        }
        static Adj_matrix create_adj_Matrix(bool isDirected)
        {
            string[] ver = getVertecies();
            int[,] edge_list = select_edge_list(isDirected);
            Adj_matrix adj_matrix = new Adj_matrix(ver.GetLength(0), isDirected, ver);
            for (int i = 0; i < edge_list.GetLength(0); i++)
            {
                adj_matrix.AddEdge(edge_list[i, 0], edge_list[i, 1]);
            }
            return adj_matrix;

        }
        static Inc_matrix create_inc_Matrix(bool isDirected)
        {
            string[] ver = getVertecies();
            int[,] edge_list = select_edge_list(isDirected);
            Inc_matrix inc_Matrix = new Inc_matrix(ver.GetLength(0), edge_list.GetLength(0),  isDirected, ver);
            for (int i = 0; i < edge_list.GetLength(0); i++)
            {
                inc_Matrix.AddEdge(edge_list[i, 0], edge_list[i, 1]);
            }
            return inc_Matrix;

        }

        static string[] getVertecies()
        {
            return new string[] { "a", "b", "c", "d", "e", "f", "g", "h" };
        //                         0    1    2    3    4    5    6    7 
        }

        static int [,] select_edge_list (bool isDirected)
        {
            int[,] directedEdges = { { 0, 1 }, { 0, 2 }, { 0, 4 }, { 1, 3 }, { 1, 4 }, { 2, 4 }, { 2, 5 }, { 3, 4 }, { 4, 7 }, { 5, 4 }, { 5, 7 }, { 6, 3 }, { 6, 4 }, { 6, 7 } };
            int[,] notDirectedEdges = { { 0, 1 }, { 0, 2 }, { 0, 4 }, { 1, 3 }, { 1, 4 }, { 2, 7 }, { 2, 5 }, { 3, 5 }, { 3, 6 }, { 7, 4 }, { 7, 5 }, { 6, 4 }, { 6, 7 } };
            if (isDirected)
            {
                return directedEdges;
            }
            else { 
                return notDirectedEdges; 
            }
        }

        
    }
}

