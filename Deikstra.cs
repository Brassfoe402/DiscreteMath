using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] graph = {
            { 0, 7, 5, 0, 0},
            { 7, 0, 3, 5, 0},
            { 5, 3, 0, 0, 4},
            { 0, 5, 0, 0, 6},
            { 0, 0, 4, 6, 0}
        };

            int[] distances = Dijkstra(graph, 0);

            Console.WriteLine("Расстояния от вершины 0:");
            for (int i = 0; i < distances.Length; i++)
            {
                Console.WriteLine("{0}: {1}", i, distances[i]);
            }
            Console.ReadLine();
        }

        public static int[] Dijkstra(int[,] graph, int source)
        {
            int n = graph.GetLength(0);
            int[] distance = new int[n];
            bool[] visited = new bool[n];
            for (int i = 0; i < n; i++)
            {
                distance[i] = int.MaxValue;
                visited[i] = false;
            }
            distance[source] = 0;

            for (int i = 0; i < n - 1; i++)
            {
                int u = MinimumDistance(distance, visited);
                visited[u] = true;

                for (int v = 0; v < n; v++)
                {
                    if (!visited[v] && graph[u, v] != 0 && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                        distance[v] = distance[u] + graph[u, v];
                }
            }
            return distance;
        }

        public static int MinimumDistance(int[] distance, bool[] visited)
        {
            int min = int.MaxValue, minIndex = -1;
            for (int i = 0; i < distance.Length; i++)
            {
                if (!visited[i] && distance[i] <= min)
                {
                    min = distance[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }
    }
}
