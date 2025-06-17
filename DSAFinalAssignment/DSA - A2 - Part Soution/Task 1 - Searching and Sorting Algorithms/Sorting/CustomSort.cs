using System;
using System.Collections.Generic;
using System.Linq;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class CustomSort : Sorter
    {
        public override List<Order> Sort(List<Order> unsortedOrderList)
        {
            // Most recent delivery date first
            return unsortedOrderList.OrderByDescending(o => o.deliverOn).ToList();
        }
    }
}
