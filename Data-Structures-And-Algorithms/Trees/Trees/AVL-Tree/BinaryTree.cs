namespace Trees.AVLTree
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    /// <summary>
    /// Binary Tree data structure
    /// </summary>
    public class BinaryTree<T> : ICollection<T>
        where T : IComparable
    {
        private BinaryTreeNode<T> head;
        private Comparison<IComparable> comparer = CompareElements;
        private int size;
        private TraverseOrder traversalMode = TraverseOrder.InOrder;

        /// <summary>
        /// Gets or sets the root of the tree (the top-most node)
        /// </summary>
        public virtual BinaryTreeNode<T> Root
        {
            get { return head; }
            set { head = value; }
        }

        public virtual Comparison<IComparable> Comparer
        {
            get { return this.comparer; }
            set { this.comparer = value; }
        }

        /// <summary>
        /// Gets whether the tree is read-only
        /// </summary>
        public virtual bool IsReadOnly
        {
            get { return false; }
        }

        /// <summary>
        /// Gets the number of elements stored in the tree
        /// </summary>
        public virtual int Count
        {
            get { return this.size; }
        }

        /// <summary>
        /// Gets or sets the traversal mode of the tree
        /// </summary>
        public virtual TraverseOrder TraversalOrder
        {
            get { return this.traversalMode; }
            set { this.traversalMode = value; }
        }

        /// <summary>
        /// Creates a new instance of a Binary Tree
        /// </summary>
        public BinaryTree()
        {
            this.head = null;
            this.size = 0;
        }

        /// <summary>
        /// Adds a new element to the tree
        /// </summary>
        public virtual void Add(T value)
        {
            BinaryTreeNode<T> node = new BinaryTreeNode<T>(value);
            this.Add(node);
        }

        /// <summary>
        /// Adds a node to the tree
        /// </summary>
        public virtual void Add(BinaryTreeNode<T> node)
        {
            // First element being added
            if (this.head == null)
            {
                // Set node as root of the tree
                this.head = node;
                node.Tree = this;
                size++;
            }
            else
            {
                if (node.Parent == null)
                {
                    // Start at head
                    node.Parent = head;
                }

                // Node is inserted on the left side if it is smaller or equal to the parent
                bool insertLeftSide = this.Comparer((IComparable)node.Value, (IComparable)node.Parent.Value) <= 0;

                // Insert on the left
                if (insertLeftSide)
                {
                    if (node.Parent.LeftChild == null)
                    {
                        node.Parent.LeftChild = node;
                        size++;
                        node.Tree = this;
                    }
                    else
                    {
                        // Recursive call to Scan down to left child
                        node.Parent = node.Parent.LeftChild;
                        this.Add(node);
                    }
                }
                // Insert on the right
                else
                {
                    if (node.Parent.RightChild == null)
                    {
                        node.Parent.RightChild = node;
                        size++;
                        node.Tree = this;
                    }
                    else
                    {
                        node.Parent = node.Parent.RightChild;
                        this.Add(node);
                    }
                }
            }
        }

        /// <summary>
        /// Returns the first node in the tree with the parameter value.
        /// </summary>
        public virtual BinaryTreeNode<T> Find(T value)
        {
            // Start at the root
            BinaryTreeNode<T> node = this.head;

            while (node != null)
            {
                // Parameter value found
                if (node.Value.Equals(value))
                {
                    return node;
                }
                else
                {
                    // Search left if the value is smaller than the current node, otherwise - search right
                    bool searchLeft = this.Comparer((IComparable)value, (IComparable)node.Value) < 0;

                    if (searchLeft)
                    {
                        node = node.LeftChild;
                    }
                    else
                    {
                        node = node.RightChild;
                    }
                }
            }

            return null;
        }

        /// <summary>
        /// Returns whether a value is stored in the tree
        /// </summary>
        public virtual bool Contains(T value)
        {
            return (this.Find(value) != null);
        }

        /// <summary>
        /// Removes a value from the tree and returns whether the removal was successful.
        /// </summary>
        public virtual bool Remove(T value)
        {
            BinaryTreeNode<T> removeNode = Find(value);

            return this.Remove(removeNode);
        }

        /// <summary>
        /// Removes a node from the tree and returns whether the removal was successful.
        /// </summary>>
        public virtual bool Remove(BinaryTreeNode<T> nodeToRemove)
        {
            // Value doesn't exist or not of this tree
            if (nodeToRemove == null || nodeToRemove.Tree != this)
            {
                return false;
            }

            // Note whether the node to be removed is the root of the tree
            bool isHead = (nodeToRemove == this.head);

            if (this.Count == 1)
            {
                // Only element was the root
                this.head = null;
                nodeToRemove.Tree = null;

                size--;
            }

            // Case 1: No Children
            else if (nodeToRemove.IsLeaf)
            {
                // Remove node from its parent
                if (nodeToRemove.IsLeftChild)
                {
                    nodeToRemove.Parent.LeftChild = null;
                }
                else
                {
                    nodeToRemove.Parent.RightChild = null;
                }

                nodeToRemove.Tree = null;
                nodeToRemove.Parent = null;

                size--;
            }

            // Case 2: One Child (Either left or right)
            else if (nodeToRemove.ChildsCount == 1)
            {
                if (nodeToRemove.HasLeftChild)
                {
                    // Put left child node in place of the node to be removed
                    nodeToRemove.LeftChild.Parent = nodeToRemove.Parent;

                    if (isHead)
                    {
                        this.Root = nodeToRemove.LeftChild;
                    }

                    if (nodeToRemove.IsLeftChild)
                    {
                        nodeToRemove.Parent.LeftChild = nodeToRemove.LeftChild;
                    }
                    else
                    {
                        nodeToRemove.Parent.RightChild = nodeToRemove.LeftChild;
                    }
                }
                else
                {
                    // Put left node in place of the node to be removed
                    nodeToRemove.RightChild.Parent = nodeToRemove.Parent;

                    if (isHead)
                    {
                        this.Root = nodeToRemove.RightChild;
                    }

                    if (nodeToRemove.IsLeftChild)
                    {
                        nodeToRemove.Parent.LeftChild = nodeToRemove.RightChild;
                    }
                    else
                    {
                        nodeToRemove.Parent.RightChild = nodeToRemove.RightChild;
                    }
                }

                nodeToRemove.Tree = null;
                nodeToRemove.Parent = null;
                nodeToRemove.LeftChild = null;
                nodeToRemove.RightChild = null;

                size--;
            }

            // Case 3: Two Children
            else
            {
                // Find inorder predecessor (right-most node in left subtree)
                BinaryTreeNode<T> successorNode = nodeToRemove.LeftChild;

                while (successorNode.RightChild != null)
                {
                    successorNode = successorNode.RightChild;
                }

                // Replace value
                nodeToRemove.Value = successorNode.Value;

                // Recursively remove the inorder predecessor
                this.Remove(successorNode);
            }

            return true;
        }

        /// <summary>
        /// Removes all the elements stored in the tree
        /// </summary>
        public virtual void Clear()
        {
            // Remove children first, then parent
            // (Post-order(Left-Right-Parent) traversal)
            IEnumerator<T> enumerator = GetPostOrderEnumerator();

            while (enumerator.MoveNext())
            {
                this.Remove(enumerator.Current);
            }

            enumerator.Dispose();
        }

        /// <summary>
        /// Returns the height of the entire tree
        /// </summary>
        public virtual int GetHeight()
        {
            return this.GetHeight(this.Root);
        }

        /// <summary>
        /// Returns the height of the subtree rooted at the parameter value
        /// </summary>
        public virtual int GetHeight(T value)
        {
            // Find the value's node in tree
            BinaryTreeNode<T> valueNode = this.Find(value);

            if (value != null)
            {
                return this.GetHeight(valueNode);
            }
            else
            {
                return 0;
            }
        }

        /// <summary>
        /// Returns the height of the subtree rooted at the parameter node
        /// </summary>
        public virtual int GetHeight(BinaryTreeNode<T> startNode)
        {
            if (startNode == null)
            {
                return 0;
            }
            else
            {
                return 1 + Math.Max(this.GetHeight(startNode.LeftChild), this.GetHeight(startNode.RightChild));
            }
        }

        /// <summary>
        /// Returns the depth of a subtree rooted at the parameter value
        /// </summary>
        public virtual int GetDepth(T value)
        {
            BinaryTreeNode<T> node = this.Find(value);
            return this.GetDepth(node);
        }

        /// <summary>
        /// Returns the depth of a subtree rooted at the parameter node
        /// </summary>
        public virtual int GetDepth(BinaryTreeNode<T> startNode)
        {
            int depth = 0;

            if (startNode == null)
            {
                return depth;
            }

            // Start a node above
            BinaryTreeNode<T> parentNode = startNode.Parent; 

            while (parentNode != null)
            {
                depth++;

                // Scan up towards the root
                parentNode = parentNode.Parent;
            }

            return depth;
        }

        /// <summary>
        /// Returns an enumerator to scan through the elements stored in tree.
        /// The enumerator uses the traversal set in the TraversalMode property.
        /// </summary>
        public virtual IEnumerator<T> GetEnumerator()
        {
            switch (this.TraversalOrder)
            {
                case TraverseOrder.InOrder:
                    {
                        return GetInOrderEnumerator();
                    }
                case TraverseOrder.PostOrder:
                    {
                        return GetPostOrderEnumerator();
                    }
                case TraverseOrder.PreOrder:
                    {
                        return GetPreOrderEnumerator();
                    }
                case TraverseOrder.RightLeftParentOrder:
                    {
                        return GetRightLeftParentOrderEnumerator();
                    }
                default:
                    {
                        return GetInOrderEnumerator();
                    }
            }
        }

        /// <summary>
        /// Returns an enumerator to scan through the elements stored in tree.
        /// The enumerator uses the traversal set in the TraversalMode property.
        /// </summary>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        /// <summary>
        /// Returns an enumerator that visits node in the order: left child, parent, right child
        /// </summary>
        public virtual IEnumerator<T> GetInOrderEnumerator()
        {
            return new BinaryTreeInOrderEnumerator(this);
        }

        /// <summary>
        /// Returns an enumerator that visits node in the order: left child, right child, parent
        /// </summary>
        public virtual IEnumerator<T> GetPostOrderEnumerator()
        {
            return new BinaryTreePostOrderEnumerator(this);
        }

        /// <summary>
        /// Returns an enumerator that visits node in the order: parent, left child, right child
        /// </summary>
        public virtual IEnumerator<T> GetPreOrderEnumerator()
        {
            return new BinaryTreePreOrderEnumerator(this);
        }

        /// <summary>
        /// Returns an enumerator that visits node in the order: right child, left child, parent
        /// </summary>
        public virtual IEnumerator<T> GetRightLeftParentOrderEnumerator()
        {
            return new BinaryTreeRightLeftParentOrderEnumerator(this);
        }

        /// <summary>
        /// Copies the elements in the tree to an array using the traversal mode specified.
        /// </summary>
        public virtual void CopyTo(T[] array)
        {
            this.CopyTo(array, 0);
        }

        /// <summary>
        /// Copies the elements in the tree to an array using the traversal mode specified.
        /// </summary>
        public virtual void CopyTo(T[] array, int startIndex)
        {
            IEnumerator<T> enumerator = this.GetEnumerator();

            for (int i = startIndex; i < array.Length; i++)
            {
                if (enumerator.MoveNext())
                {
                    array[i] = enumerator.Current;
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Compares two elements to determine their positions within the tree.
        /// </summary>
        public static int CompareElements(IComparable x, IComparable y)
        {
            return x.CompareTo(y);
        }

        /// <summary>
        /// Returns an inorder-traversal enumerator for the tree values
        /// </summary>
        internal class BinaryTreeInOrderEnumerator : IEnumerator<T>
        {
            private BinaryTreeNode<T> current;
            private BinaryTree<T> tree;
            internal Queue<BinaryTreeNode<T>> traverseQueue;

            public BinaryTreeInOrderEnumerator(BinaryTree<T> tree)
            {
                this.tree = tree;

                // Build queue
                traverseQueue = new Queue<BinaryTreeNode<T>>();
                this.VisitNode(this.tree.Root);
            }

            private void VisitNode(BinaryTreeNode<T> node)
            {
                if (node == null)
                {
                    return;
                }
                else
                {
                    this.VisitNode(node.LeftChild);
                    traverseQueue.Enqueue(node);
                    this.VisitNode(node.RightChild);
                }
            }

            public T Current
            {
                get { return current.Value; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                current = null;
                tree = null;
            }

            public void Reset()
            {
                current = null;
            }

            public bool MoveNext()
            {
                if (traverseQueue.Count > 0)
                {
                    current = traverseQueue.Dequeue();
                }
                else
                {
                    current = null;
                }

                return (current != null);
            }
        }

        /// <summary>
        /// Returns a postorder-traversal enumerator for the tree values
        /// </summary>
        internal class BinaryTreePostOrderEnumerator : IEnumerator<T>
        {
            private BinaryTreeNode<T> current;
            private BinaryTree<T> tree;
            internal Queue<BinaryTreeNode<T>> traverseQueue;

            public BinaryTreePostOrderEnumerator(BinaryTree<T> tree)
            {
                this.tree = tree;

                //Build queue
                traverseQueue = new Queue<BinaryTreeNode<T>>();
                this.VisitNode(this.tree.Root);
            }

            private void VisitNode(BinaryTreeNode<T> node)
            {
                if (node == null)
                {
                    return;
                }
                else
                {
                    this.VisitNode(node.LeftChild);
                    this.VisitNode(node.RightChild);
                    traverseQueue.Enqueue(node);
                }
            }

            public T Current
            {
                get { return current.Value; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                current = null;
                tree = null;
            }

            public void Reset()
            {
                current = null;
            }

            public bool MoveNext()
            {
                if (traverseQueue.Count > 0)
                {
                    current = traverseQueue.Dequeue();
                }
                else
                {
                    current = null;
                }

                return (current != null);
            }
        }

        /// <summary>
        /// Returns an preorder-traversal enumerator for the tree values
        /// </summary>
        internal class BinaryTreePreOrderEnumerator : IEnumerator<T>
        {
            private BinaryTreeNode<T> current;
            private BinaryTree<T> tree;
            internal Queue<BinaryTreeNode<T>> traverseQueue;

            public BinaryTreePreOrderEnumerator(BinaryTree<T> tree)
            {
                this.tree = tree;

                //Build queue
                traverseQueue = new Queue<BinaryTreeNode<T>>();
                visitNode(this.tree.Root);
            }

            private void visitNode(BinaryTreeNode<T> node)
            {
                if (node == null)
                {
                    return;
                }
                else
                {
                    traverseQueue.Enqueue(node);
                    visitNode(node.LeftChild);
                    visitNode(node.RightChild);
                }
            }

            public T Current
            {
                get { return current.Value; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                current = null;
                tree = null;
            }

            public void Reset()
            {
                current = null;
            }

            public bool MoveNext()
            {
                if (traverseQueue.Count > 0)
                {
                    current = traverseQueue.Dequeue();
                }
                else
                {
                    current = null;
                }

                return (current != null);
            }
        }

        /// <summary>
        /// Returns a right-left-parent-traversal enumerator for the tree values
        /// </summary>
        internal class BinaryTreeRightLeftParentOrderEnumerator : IEnumerator<T>
        {
            private BinaryTreeNode<T> current;
            private BinaryTree<T> tree;
            internal Queue<BinaryTreeNode<T>> traverseQueue;

            public BinaryTreeRightLeftParentOrderEnumerator(BinaryTree<T> tree)
            {
                this.tree = tree;

                //Build queue
                traverseQueue = new Queue<BinaryTreeNode<T>>();
                this.VisitNode(this.tree.Root);
            }

            private void VisitNode(BinaryTreeNode<T> node)
            {
                if (node == null)
                {
                    return;
                }
                else
                {
                    this.VisitNode(node.RightChild);
                    this.VisitNode(node.LeftChild);
                    traverseQueue.Enqueue(node);
                }
            }

            public T Current
            {
                get { return current.Value; }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                current = null;
                tree = null;
            }

            public void Reset()
            {
                current = null;
            }

            public bool MoveNext()
            {
                if (traverseQueue.Count > 0)
                {
                    current = traverseQueue.Dequeue();
                }
                else
                {
                    current = null;
                }

                return (current != null);
            }
        }
    }
}