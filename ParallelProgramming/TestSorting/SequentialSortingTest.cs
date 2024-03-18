using System;
using Xunit;
using CountingSort;
using System.Collections.Generic;

namespace TestSorting
{
    public class SequentialSortingTest
    {
        [Fact]
        public void EmptyArray()
        {
            SequentialSorting seqSorting = new SequentialSorting();
            List<int> list = new List<int>();
            int k = 1000;

            List<int> sortedList = seqSorting.Sort(list, k);

            Assert.Equal(list, sortedList);
        }

        [Fact]
        public void ArrayWith1Element()
        {
            SequentialSorting seqSorting = new SequentialSorting();
            List<int> list = new List<int>() { 3 };
            int k = 5;

            List<int> sortedList = seqSorting.Sort(list, k);

            Assert.Equal(list, sortedList);
        }

        [Fact]
        public void ArrayWith2Element_NotSorted()
        {
            SequentialSorting seqSorting = new SequentialSorting();
            List<int> list = new List<int>() { 3, 1};
            List<int> expected = new List<int>() { 1, 3 };
            int k = 5;

            List<int> sortedList = seqSorting.Sort(list, k);

            Assert.Equal(expected, sortedList);
        }

        [Fact]
        public void ArrayWith2Element_Sorted()
        {
            SequentialSorting seqSorting = new SequentialSorting();
            List<int> list = new List<int>() { 3, 1 };
            List<int> expected = new List<int>() { 1, 3 };
            int k = 5;

            List<int> sortedList = seqSorting.Sort(list, k);

            Assert.Equal(expected, sortedList);
        }


        [Fact]
        public void ArrayWith10Element()
        {
            SequentialSorting seqSorting = new SequentialSorting();
            List<int> list = new List<int>() { 3, 77, 9, 28, 7, 18, 45, 2, 1, 13};
            List<int> expected = new List<int>() { 1, 2, 3, 7, 9, 13, 18, 28, 45, 77 };
            int k = 100;

            List<int> sortedList = seqSorting.Sort(list, k);

            Assert.Equal(expected, sortedList);
        }
    }
}
