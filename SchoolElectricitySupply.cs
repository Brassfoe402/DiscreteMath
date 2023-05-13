using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите количество школ: ");
            int n = int.Parse(Console.ReadLine()); 
            Console.WriteLine("Введите количество возможных соединений: ");
            int m = int.Parse(Console.ReadLine()); 
            int[,] graph = new int[n, n]; // матрица смежности

            // заполнение матрицы смежности
            for (int i = 0; i < m; i++)
            {
                Console.WriteLine("Введите через пробел номера двух школ и стоимость соединения: ");
                string[] input = Console.ReadLine().Split();
                int a = int.Parse(input[0]) - 1; 
                int b = int.Parse(input[1]) - 1; 
                int c = int.Parse(input[2]); 
                graph[a, b] = c;
                graph[b, a] = c;
            }

            int min1 = int.MaxValue, min2 = int.MaxValue; 
            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    if (graph[i, j] > 0) // если школы можно соединить
                    {
                        int cost1 = 0, cost2 = 0;
                        for (int k = 0; k < n; k++)
                        {
                            if (k != i && k != j) // для всех остальных школ
                            {
                                if (graph[i, k] > 0 && graph[k, j] > 0) // если они соединены с i и j
                                {
                                    cost1 += graph[i, k] + graph[k, j];
                                    cost2 += Math.Min(graph[i, k], graph[k, j]);
                                }
                                else if (graph[i, k] > 0)
                                {
                                    cost1 += graph[i, k];
                                    cost2 += graph[i, k];
                                }
                                else if (graph[k, j] > 0) // если соединена только с j
                                {
                                    cost1 += graph[k, j];
                                    cost2 += graph[k, j];
                                }
                                else // если школа не соединена ни с i, ни с j
                                {
                                    cost2 = int.MaxValue; 
                                    break;
                                }
                                }
                        }

                        if (cost1 < min1) // обновляем первую минимальную стоимость
                        {
                            min2 = min1;
                            min1 = cost1;
                        }
                        else if (cost1 < min2 && cost1 > min1) // обновляем вторую минимальную стоимость
                        {
                            min2 = cost1;
                        }

                        if (cost2 < min2 && cost2 > min1) // обновляем вторую минимальную стоимость
                        {
                            min2 = cost2;
                        }
                    }
                }
            }

            Console.WriteLine($"{min1} {min2}");
            Console.ReadKey();
        }
    }
}

