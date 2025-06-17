using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class PriorityQueue
    {
        private Heap priorityQueue;

        private void Build(List<Order> orders)
        {
            priorityQueue = new Heap(orders.Count);
            foreach (var order in orders)
                priorityQueue.Insert(order);
        }

        public List<Order> GetMostUrgentOrders(List<Order> orders)
        {
            Build(orders);
            var urgent = new List<Order>();
            for (int i = 0; i < 5 && orders.Count > 0; i++)
            {
                var order = priorityQueue.Remove();
                if (order != null)
                    urgent.Add(order);
            }
            return urgent;
        }
    }
}
