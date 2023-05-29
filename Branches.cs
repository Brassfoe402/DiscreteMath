using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp8
{
    class Program
    {
        static void Main(string[] args)
        {
            var abs_min = 0;
            int[,] mat = { { -1, 6, 4, 8, 7 },
                              { 6, -1, 7, 11, 7 },
                              { 4, 7, -1, 4, 3 },
                              { 8, 11, 4, -1, 5 },
                              { 7, 7, 3, 5, -1 } };

            for (int p = 0; p < mat.GetLength(0) - 1; p++)
            {
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    int min = int.MaxValue;
                    for (int j = 0; j < mat.GetLength(1); j++)
                    {
                        if (mat[i, j] < min && mat[i, j] >= 0)
                            min = mat[i, j];
                    }

                    if (min == int.MaxValue)
                        min = 0;
                    abs_min += min;

                    for (int j = 0; j < mat.GetLength(0); j++)
                    {
                        if (mat[i, j] >= 0)
                            mat[i, j] -= min;
                    }

                }

                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    for (int j = 0; j < mat.GetLength(1); j++)
                        Console.Write(mat[i, j] + " ");
                    Console.WriteLine();
                }
                Console.WriteLine(abs_min);

                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    int min = int.MaxValue;
                    for (int j = 0; j < mat.GetLength(1); j++)
                    {
                        if (mat[j, i] < min && mat[j, i] >= 0)
                            min = mat[j, i];
                    }

                    if (min == int.MaxValue)
                        min = 0;
                    abs_min += min;

                    for (int j = 0; j < mat.GetLength(0); j++)
                    {
                        if (mat[j, i] >= 0)
                            mat[j, i] -= min;
                    }
                }

                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    for (int j = 0; j < mat.GetLength(1); j++)
                        Console.Write(mat[i, j] + " ");
                    Console.WriteLine();
                }

                Console.WriteLine(abs_min);

                var nulmax = -10000;
                var stolbj = 0;
                var stolbi = 0;
                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    for (int j = 0; j < mat.GetLength(1); j++)
                    {
                        if (mat[i, j] == 0)
                        {
                            int sum1 = int.MaxValue;
                            int sum2 = int.MaxValue;
                            for (int k = 0; k < mat.GetLength(0); k++)
                            {
                                if (k != j)
                                {
                                    if (mat[i, k] < sum1 && mat[i, k] >= 0)
                                        sum1 = mat[i, k];
                                }
                            }
                            for (int l = 0; l < mat.GetLength(1); l++)
                            {
                                if (l != i)
                                {
                                    if (mat[l, j] < sum2 && mat[l, j] >= 0)
                                        sum2 = mat[l, j];
                                }
                            }
                            if (sum1 + sum2 > nulmax)
                            {
                                nulmax = sum1 + sum2;
                                stolbi = i;
                                stolbj = j;
                            }
                        }
                    }
                }

                var index = 0;
                mat[stolbj, stolbi] = -1;

                if (p > 0)
                {
                    for (int i = 0; i < mat.GetLength(0); i++)
                    {
                        for (int j = 0; j < mat.GetLength(0); j++)
                        {
                            if (mat[i, j] != -1)
                            {
                                mat[i, j] = -1;
                                index = j;
                                break;
                            }
                        }
                        if (mat[i, index] == 0)
                            break;
                    }
                }

                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    for (int j = 0; j < mat.GetLength(1); j++)
                        Console.Write(mat[i, j] + " ");
                    Console.WriteLine();
                }

                for (int i = 0; i < mat.GetLength(0); i++)
                    mat[stolbi, i] = -1;

                for (int i = 0; i < mat.GetLength(0); i++)
                    mat[i, stolbj] = -1;

                for (int i = 0; i < mat.GetLength(0); i++)
                {
                    for (int j = 0; j < mat.GetLength(1); j++)
                        Console.Write(mat[i, j] + " ");
                    Console.WriteLine();
                }
                Console.WriteLine(abs_min + "\n");
            }
        }

    }
}