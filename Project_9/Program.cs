using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[,] ints = new int[4, 3];
            Console.WriteLine(ints.Rank);   //2
            Console.WriteLine(ints.Length); //12
            Console.WriteLine(ints.GetLength(0)); //4
            Console.WriteLine(ints.GetLength(1)); //3
            //Console.WriteLine(ints.GetLength(2)); //out-of-range
            Console.WriteLine();

            for (int i = 0; i < ints.GetLength(0); i++)
            {
                for (int j = 0; j < ints.GetLength(1); j++)
                {
                    Console.WriteLine($"ints[{i},{j}] = {ints[i, j]}");
                }
            }
            Console.WriteLine();
            
            int[,,] cubs = new int[4, 3, 2];
            for (int i = 0; i < cubs.GetLength(0); i++)
            {
                Console.WriteLine($"cubs[{i}]");
                for(int j = 0; j < cubs.GetLength(1); j++)
                {
                    Console.WriteLine($"\tcubs[{i},{j}]");
                    for (int k = 0; k < cubs.GetLength(2); k++)
                    {
                        Console.WriteLine($"\t\tcubs[{i},{j},{k}] = {cubs[i, j, k]}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            int[,] matrix = new int[,] { { 1, 2, 3 }, { 4, 5, 6 } };
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.WriteLine($"matrix[{i}, {j}]={matrix[i, j]}");
                }
                Console.WriteLine();
            }
            Console.WriteLine();

            double[,,] cube = new double[,,] 
            { 
                { 
                    { 1.11, 1.12, 1.13}, 
                    { 1.21, 1.22, 1.23}, 
                    { 1.31, 1.32, 1.33} 
                }, 
                { 
                    { 2.11, 2.12, 2.13 }, 
                    { 2.21, 2.22, 2.23 }, 
                    { 2.31, 2.32, 2.33 } 
                }, 
                { 
                    { 3.11, 3.12, 3.13 }, 
                    { 3.21, 3.22, 3.23 }, 
                    { 3.31, 3.32, 3.33 } 
                } 
            };

            for (int i = 0; i < cube.GetLength(0); i++)
            {
                Console.WriteLine($"cube[{i}]");
                for (int j = 0; j < cube.GetLength(1); j++)
                {
                    Console.WriteLine($"\tcube[{i},{j}]");
                    for (int k = 0; k < cube.GetLength(2); k++)
                    {
                        Console.WriteLine($"\t\tcube[{i},{j},{k}] = {cube[i, j, k]}");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
            Console.WriteLine();







            Console.ReadLine();
        }




    }
}
