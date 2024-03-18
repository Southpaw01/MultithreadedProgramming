using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingSort
{
    public class WrongParallelSorting
    {

        int[] C = new int[120000];

        public List<int> RaceCondition(List<int> origList)
        {
            int n = origList.Count;

            Parallel.For(0, n, i =>
            {
                C[origList[i]] += 1;
            });

            List<int> newA = new List<int>(n);

            for (int j = 0; j < C.Length; j++)
            {
                Parallel.For(0, C[j], i =>
                {
                    newA.Add(j);
                });
            }

            return newA;
        }


        List<int> origList = new List<int>();
        List<int> sortedList = new List<int>(10000000);
        int[] C1 = new int[60000];
        int[] C2 = new int[120000];
        public List<int> DeadLock(List<int> origList)
        {
            this.origList = origList;

            List<Task> tasks = new List<Task>();
            tasks.Add(new Task(FillC1));
            tasks.Add(new Task(FillC2));

            foreach (var t in tasks)
            {
                t.Start();
            }

            Task.WaitAll(tasks.ToArray());

            return sortedList;
        }

        object _s1 = new object();
        object _s2 = new object();

        void FillC1()
        {
            for (int i = 0; i < origList.Count / 2; i++)
            {
                lock (_s1)
                {
                    lock (_s2)
                    {
                        Console.WriteLine(i + ". " + origList[i]);
                        if (origList[i] < 60000)
                        {
                            C1[origList[i]] += 1;
                        }
                        else
                        {
                            C2[origList[i]] += 1;
                        }
                    }
                }
            }
        }

        void FillC2()
        {
            for (int i = origList.Count / 2; i < origList.Count; i++)
            {
                lock (_s2)
                {
                    lock (_s1)
                    {
                        Console.WriteLine(i + ". " + origList[i]);
                        if (origList[i] >= 60000)
                        {
                            C2[origList[i]] += 1;
                        }
                        else C1[origList[i]] += 1;
                    }
                }
                    
            }
        }

        object locker1 = new();
        object locker2 = new();
        public List<int> LockSharedResource(List<int> origList)
        {
            int n = origList.Count;

            Parallel.For(0, n, i =>
            {
                lock (locker1)
                {
                    C[origList[i]] += 1;
                }
            });

            List<int> newA = new List<int>(n);

            for (int j = 0; j < C.Length; j++)
            {
                Parallel.For(0, C[j], i =>
                {
                    lock (locker2)
                    {
                        newA.Add(j);
                    }
                });
            }

            return newA;
        }



    }
}
