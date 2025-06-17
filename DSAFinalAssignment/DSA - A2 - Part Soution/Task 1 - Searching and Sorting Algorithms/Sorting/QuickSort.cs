using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class QuickSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            var list = new List<Order>(unsortedOrderList);
            QuickSortHelper(list, 0, list.Count - 1);
            return list;
        }

        private void QuickSortHelper(List<Order> list, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(list, low, high);
                QuickSortHelper(list, low, pivotIndex - 1);
                QuickSortHelper(list, pivotIndex + 1, high);
            }
        }

        private int Partition(List<Order> list, int low, int high)
        {
            var pivot = list[low].ID;
            int left = low + 1;
            int right = high;

            while (true)
            {
                while (left <= right && list[left].ID.CompareTo(pivot) <= 0) left++;
                while (left <= right && list[right].ID.CompareTo(pivot) > 0) right--;

                if (left > right) break;

                var temp = list[left];
                list[left] = list[right];
                list[right] = temp;
            }

            var temp2 = list[low];
            list[low] = list[right];
            list[right] = temp2;

            return right;
        }
    }
}
