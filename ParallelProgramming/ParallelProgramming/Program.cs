using System;
using System.Collections.Generic;
using System.Diagnostics;
using CountingSort;
using TestSorting;

namespace ParallelProgramming
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 500000000;
            int k = 120000;

            Console.WriteLine("The filling of the List with random values has begun...");

            List<int> A = GenerateList(n, k);

       //    Tests.CheckSortingCorrect(A, k);

            Tests.CheckSortingTime(A, k);


            Console.ReadKey(true);

        }

        static List<int> GenerateList(int n, int k)
        {
            Random rnd = new Random();
            List<int> A = new List<int>();

            for (int i = 0; i < n; i++)
            {
                A.Add(rnd.Next(0, k));
            }

            return A;
        }

    }
}
