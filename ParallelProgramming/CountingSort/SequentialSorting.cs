using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountingSort
{
    public class SequentialSorting
    {
        public List<int> Sort(List<int> origList, int k)
        {
            int[] C = new int[k];
            int n = origList.Count;

            for (int i = 0; i < n; i++)
            {
                C[origList[i]] += 1;
            }

            List<int> sortedList = new List<int>(n);
            for (int j = 0; j < C.Length; j++)
            {
                for (int i = 0; i < C[j]; i++)
                {
                    sortedList.Add(j);
                }
            }

            return sortedList;
        }

    }
}
