using System;
using System.Collections.Generic;

namespace Task_1___Searching_and_Sorting_Algorithms
{
    internal class BinarySearchTree
    {
        public TreeNode Root { get; private set; }

        public void Build(List<Order> Orders)
        {
            Root = null;
            foreach (var order in Orders)
                Root = Insert(Root, order);
        }

        private TreeNode Insert(TreeNode node, Order order)
        {
            if (node == null)
                return new TreeNode(order);

            int cmp = order.ID.CompareTo(node.order.ID);
            if (cmp < 0)
                node.Left = Insert(node.Left, order);
            else if (cmp > 0)
                node.Right = Insert(node.Right, order);

            return node;
        }

        public Order Get(Guid orderID)
        {
            return Get(Root, orderID);
        }

        private Order Get(TreeNode node, Guid orderID)
        {
            if (node == null)
                return null;
            int cmp = orderID.CompareTo(node.order.ID);
            if (cmp == 0)
                return node.order;
            else if (cmp < 0)
                return Get(node.Left, orderID);
            else
                return Get(node.Right, orderID);
        }
    }
}
