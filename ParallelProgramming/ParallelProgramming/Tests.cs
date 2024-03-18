using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CountingSort;

namespace ParallelProgramming
{
    public static class Tests
    {
        public static void CheckSortingCorrect(List<int> A, int k)
        {
            List<int> newA;
            SequentialSorting seqSort = new SequentialSorting();
            ParallelSorting parSort = new ParallelSorting();

            Console.WriteLine("Count of elements in original list - " + A.Count + "\n");

            newA = seqSort.Sort(A, k);
            Console.WriteLine("Sequential Sorting");
            Console.WriteLine("Sorting is correct - " + IsSorted(newA));
            Console.WriteLine("Count of elemenrs in sorted list - " + newA.Count);
            Console.WriteLine();

            newA = parSort.Sort3(A, k);
            Console.WriteLine("Parallel sorting with 3 threads");
            Console.WriteLine("Sorting is correct - " + IsSorted(newA));
            Console.WriteLine("Count of elemenrs in sorted list - " + newA.Count);
            Console.WriteLine();

            newA = parSort.Sort4(A, k);
            Console.WriteLine("Parallel sorting with 4 threads");
            Console.WriteLine("Sorting is correct - " + IsSorted(newA));
            Console.WriteLine("Count of elemenrs in sorted list - " + newA.Count);
            Console.WriteLine();

            newA = parSort.Sort6(A, k);
            Console.WriteLine("Parallel sorting with 6 threads");
            Console.WriteLine("Sorting is correct - " + IsSorted(newA));
            Console.WriteLine("Count of elemenrs in sorted list - " + newA.Count);
            Console.WriteLine();
        }

        public static void CheckSortingTime(List<int> A, int k)
        {
            SequentialSorting seqSort = new SequentialSorting();
            ParallelSorting parSort = new ParallelSorting();
            WrongParallelSorting wrongSort = new();

            Console.WriteLine("Count of elements in original list - " + A.Count + "\n");

            Stopwatch watch = new Stopwatch();

            watch.Restart();

            seqSort.Sort(A, k);

            watch.Stop();

            Console.WriteLine("Sequential Sorting - " + watch.Elapsed);
            Console.WriteLine();

            //watch.Restart();

            //wrongSort.LockSharedResource(A);

            //watch.Stop();

            //Console.WriteLine("Parallel Sorting with lock shared resource - " + watch.Elapsed);
            //Console.WriteLine();

            watch.Restart();

            parSort.Sort3(A, k);

            watch.Stop();

            Console.WriteLine("Parallel sorting with 3 threads - " + watch.Elapsed);
            Console.WriteLine();

            watch.Restart();

            parSort.Sort4(A, k);

            watch.Stop();

            Console.WriteLine("Parallel sorting with 4 threads - " + watch.Elapsed);
            Console.WriteLine();

            watch.Restart();

            parSort.Sort6(A, k);

            watch.Stop();

            Console.WriteLine("Parallel sorting with 6 threads - " + watch.Elapsed);
            Console.WriteLine();
        }

        public static bool IsSorted(List<int> arr)
        {
            for (int i = 0; i < arr.Count - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    return false;
                }
            }

            return true;
        }

    }
}
