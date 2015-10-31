using System;

namespace Trees.AVLTree
{
    public class Startup
    {
        public static void Main()
        {
            AVLTree<int> tree = new AVLTree<int>();

            AddElements(tree, 15);

            PrintTree(tree, TraverseOrder.InOrder);
            PrintTree(tree, TraverseOrder.PreOrder);
            PrintTree(tree, TraverseOrder.PostOrder);
            PrintTree(tree, TraverseOrder.RightLeftOrder);
        }

        public static void PrintTree(BinaryTree<int> binaryTree, TraverseOrder traverseOrder)
        {
            binaryTree.TraversalOrder = traverseOrder;

            Console.WriteLine("{0} ", traverseOrder.ToString());

            foreach (var node in binaryTree)
            {
                Console.Write("{0} ", node);
            }

            Console.WriteLine();
        }

        public static void AddElements(BinaryTree<int> binaryTree, int count)
        {
            for (int i = 0; i < count; i++)
            {
                binaryTree.Add(i);
            }
        }
    }
}