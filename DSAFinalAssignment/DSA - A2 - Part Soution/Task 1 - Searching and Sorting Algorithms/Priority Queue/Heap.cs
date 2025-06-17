using System;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class Heap
    {
        private Order[] orderHeap;
        private int size = 0;

        public Heap(int maxSize)
        {
            orderHeap = new Order[maxSize];
        }

        public void Insert(Order order)
        {
            if (size >= orderHeap.Length)
                throw new InvalidOperationException("Heap full");
            orderHeap[size] = order;
            HeapifyUp(size);
            size++;
        }

        private void HeapifyUp(int index)
        {
            while (index > 0)
            {
                int parent = (index - 1) / 2;
                if (orderHeap[index].deliverOn >= orderHeap[parent].deliverOn)
                    break;
                var temp = orderHeap[index];
                orderHeap[index] = orderHeap[parent];
                orderHeap[parent] = temp;
                index = parent;
            }
        }

        public Order Remove()
        {
            if (size == 0)
                return null;
            var min = orderHeap[0];
            orderHeap[0] = orderHeap[size - 1];
            size--;
            HeapifyDown(0);
            return min;
        }

        private void HeapifyDown(int index)
        {
            while (index < size)
            {
                int left = 2 * index + 1, right = 2 * index + 2, smallest = index;
                if (left < size && orderHeap[left].deliverOn < orderHeap[smallest].deliverOn)
                    smallest = left;
                if (right < size && orderHeap[right].deliverOn < orderHeap[smallest].deliverOn)
                    smallest = right;
                if (smallest == index)
                    break;
                var temp = orderHeap[index];
                orderHeap[index] = orderHeap[smallest];
                orderHeap[smallest] = temp;
                index = smallest;
            }
        }
    }
}
