using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CountingSort
{
    public class ParallelSorting
    {

        public List<int> Sort3(List<int> origArr, int k)
        {
            int n = origArr.Count;
            int[] C = new int[k];
            List<int> newA1 = new List<int>(40000), newA2 = new List<int>(40000), newA3 = new List<int>(40000);

            Parallel.Invoke(
                () =>
            {
                newA1 = GetResult(origArr, 0, 40000);
            },
                () =>
            {
                newA2 = GetResult(origArr, 40000, 80000);
            },
                () =>
            {
                newA3 = GetResult(origArr, 80000, 120000);
            });

            return newA1.Concat(newA2).Concat(newA3).ToList();
        }


        int[] FillC(List<int> arr, int[] C)
        {
            for (int i = 0; i < arr.Count; i++)
            {
                C[arr[i]] += 1;
            }

            return C;
        }

        List<int> CreateSortedList(int[] C, int n)
        {
            List<int> newA = new List<int>(40000);

            for (int j = n; j < C.Length; j++)
            {
                for (int k = 0; k < C[j]; k++)
                {
                    newA.Add(j);
                }
            }

            return newA;
        }

        List<int> GetResult(List<int> origArr, int min, int max)
        {
            List<int> arr = origArr.Where(x => x >= min && x < max).ToList();
            int[] C = new int[max];

            C = FillC(arr, C);

            return CreateSortedList(C, min);
        }


        public List<int> Sort4(List<int> origArr, int k)
        {
            int n = origArr.Count;
            List<int> newA1 = new List<int>(30000), newA2 = new List<int>(30000), newA3 = new List<int>(30000);
            List<int> newA4 = new List<int>(30000);

            Parallel.Invoke(
                () =>
                {
                    newA1 = GetResult(origArr, 0, 30000);
                },
                () =>
                {
                    newA2 = GetResult(origArr, 30000, 60000);
                },
                () =>
                {
                    newA3 = GetResult(origArr, 60000, 90000);
                },
                () =>
                {
                    newA4 = GetResult(origArr, 90000, 120000);
                });

            return newA1.Concat(newA2).Concat(newA3).Concat(newA4).ToList();
        }

        public List<int> Sort6(List<int> origArr, int k)
        {
            int n = origArr.Count;
            List<int> newA1 = new List<int>(20000), newA2 = new List<int>(20000), newA3 = new List<int>(20000);
            List<int> newA4 = new List<int>(20000), newA5 = new List<int>(20000), newA6 = new List<int>(20000);

            Parallel.Invoke(
                () =>
                {
                    newA1 = GetResult(origArr, 0, 20000);
                },
                () =>
                {
                    newA2 = GetResult(origArr, 20000, 40000);
                },
                () =>
                {
                    newA3 = GetResult(origArr, 40000, 60000);
                },
                () =>
                {
                    newA4 = GetResult(origArr, 60000, 80000);
                },
                () =>
                {
                    newA5 = GetResult(origArr, 80000, 100000);
                },
                () =>
                {
                    newA6 = GetResult(origArr, 100000, 120000);
                });


            return newA1.Concat(newA2).Concat(newA3).Concat(newA4).Concat(newA5).Concat(newA6).ToList();
        }

    }
}
