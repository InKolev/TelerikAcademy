namespace Tree_Of_N_Nodess
{
    using System;
    using System.Collections.Generic;

    public class Tree<T>
        where T : IComparable<T>
    {
        private TreeNode<T> root;
        private int size;

        public Tree(TreeNode<T> parent, T value)
            : this(new TreeNode<T>(parent, value))
        {
        }

        public Tree(TreeNode<T> root)
        {
            this.Root = root;
        }

        public Tree(TreeNode<T> parent, T value, params TreeNode<T>[] children)
            : this(parent, value)
        {
            foreach (var child in children)
            {
                this.root.AddChild(child);
            }
        }

        public Tree(TreeNode<T> root, params TreeNode<T>[] children)
            : this(root)
        {
            foreach (var child in children)
            {
                this.root.AddChild(child);
            }
        }

        public TreeNode<T> Root
        {
            get { return this.root; }
            private set { this.root = value; }
        }

        private void TraverseDFS(TreeNode<T> root, string identation)
        {
            if (root == null)
            {
                return;
            }

            // Process the visited node
            Console.WriteLine(identation + root.Value);

            TreeNode<T> child = null;

            for (int i = 0; i < root.ChildrenCount; i++)
            {
                child = root.GetChild(i);
                this.TraverseDFS(child, identation + "----");
            }
        }

        public void TraverseDFS()
        {
            this.TraverseDFS(this.root, string.Empty);
        }

        public void TraverseDFSWithStack()
        {
            Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
            stack.Push(this.root);

            while (stack.Count > 0)
            {
                TreeNode<T> currentNode = stack.Pop();

                Console.Write("{0} ", currentNode.Value);

                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChild(i);
                    stack.Push(childNode);
                }
            }
        }

        public void TraverseBFSWithQueue()
        {
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
                TreeNode<T> currentNode = queue.Dequeue();

                Console.Write("{0} ", currentNode.Value);

                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChild(i);
                    queue.Enqueue(childNode);
                }
            }
        }
    }
}
