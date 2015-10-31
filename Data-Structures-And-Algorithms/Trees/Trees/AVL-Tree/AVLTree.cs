namespace Trees.AVLTree
{
    using System;

    /// <summary>
    /// AVL Tree data structure
    /// </summary>
    public class AVLTree<T> : BinaryTree<T>
        where T : IComparable
    {
        /// <summary>
        /// Returns the AVL Node of the tree
        /// </summary>
        public new AVLTreeNode<T> Root
        {
            get { return (AVLTreeNode<T>)base.Root; }
            set { base.Root = value; }
        }

        /// <summary>
        /// Returns the AVL Node corresponding to the given value
        /// </summary>
        public new AVLTreeNode<T> Find(T value)
        {
            return (AVLTreeNode<T>)base.Find(value);
        }

        /// <summary>
        /// Insert a value in the tree and rebalance the tree if necessary.
        /// </summary>
        public override void Add(T value)
        {
            AVLTreeNode<T> node = new AVLTreeNode<T>(value);

            // Add normally
            base.Add(node);

            // Balance every node going up, starting with the parent
            AVLTreeNode<T> parentNode = node.Parent;

            while (parentNode != null)
            {
                int balance = this.GetBalance(parentNode);

                // Balance factor of (-2) or (2) defines an unbalanced tree
                if (Math.Abs(balance) == 2)
                {
                    // Rebalance tree
                    this.BalanceAt(parentNode, balance);
                }

                // Keep going up
                parentNode = parentNode.Parent;
            }
        }

        /// <summary>
        /// Removes a given value from the tree and rebalances the tree if necessary.
        /// </summary>
        public override bool Remove(T value)
        {
            AVLTreeNode<T> valueNode = this.Find(value);
            return this.Remove(valueNode);
        }

        /// <summary>
        /// Wrapper method for removing a node within the tree
        /// </summary>
        protected new bool Remove(BinaryTreeNode<T> removeNode)
        {
            return this.Remove((AVLTreeNode<T>)removeNode);
        }

        /// <summary>
        /// Removes a given node from the tree and rebalances the tree if necessary.
        /// </summary>
        public bool Remove(AVLTreeNode<T> nodeForRemoval)
        {
            // Save reference of the parent node which has to be removed
            AVLTreeNode<T> parentNode = nodeForRemoval.Parent;

            // Remove the node as usual
            bool removed = base.Remove(nodeForRemoval);

            if (!removed)
            {
                // Removing failed, no need to rebalance
                return false; 
            }
            else
            {
                // Balance going up the tree
                while (parentNode != null)
                {
                    int balance = this.GetBalance(parentNode);

                    // Balace factor is either (1) or (-1), no need for rebalance.
                    if (Math.Abs(balance) == 1)
                    {
                        break;
                    }

                    // Balance factor is either (2) or (-2), must rebalance.
                    else if (Math.Abs(balance) == 2) 
                    {
                        this.BalanceAt(parentNode, balance);
                    }

                    parentNode = parentNode.Parent;
                }

                return true;
            }
        }

        /// <summary>
        /// Balances an AVL Tree node
        /// </summary>
        protected virtual void BalanceAt(AVLTreeNode<T> node, int balance)
        {
            // Right outweights
            if (balance == 2)
            {
                int rightBalance = GetBalance(node.RightChild);

                if (rightBalance == 1 || rightBalance == 0)
                {
                    // Left rotation
                    RotateLeft(node);
                }
                else if (rightBalance == -1)
                {
                    // Right-Left rotation
                    RotateRight(node.RightChild);
                    RotateLeft(node);
                }
            }

            // Left outweights
            else if (balance == -2)
            {
                int leftBalance = GetBalance(node.LeftChild);

                if (leftBalance == 1)
                {
                    // Left-Right rotation
                    RotateLeft(node.LeftChild);
                    RotateRight(node);
                }
                else if (leftBalance == -1 || leftBalance == 0)
                {
                    // Right rotation needed
                    RotateRight(node);
                }
            }
        }

        /// <summary>
        /// Determines the balance of a given node
        /// </summary>
        protected virtual int GetBalance(AVLTreeNode<T> root)
        {
            // Balance Factor = (Right child's height - Left child's height)
            return this.GetHeight(root.RightChild) - this.GetHeight(root.LeftChild);
        }

        /// <summary>
        /// Rotates a node to the left within an AVL Tree
        /// </summary>
        protected virtual void RotateLeft(AVLTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }

            AVLTreeNode<T> pivot = root.RightChild;

            if (pivot == null)
            {
                return;
            }
            else
            {
                AVLTreeNode<T> rootParent = root.Parent;

                // Determines whether the root was the parent's left node
                bool isLeftChild = (rootParent != null) && (rootParent.LeftChild == root);

                // Determines whether the root was the root of the entire tree
                bool isTreeRoot = (root.Tree.Root == root);

                // Rotate
                root.RightChild = pivot.LeftChild;
                pivot.LeftChild = root;

                // Update parents
                root.Parent = pivot;
                pivot.Parent = rootParent;

                if (root.RightChild != null)
                {
                    root.RightChild.Parent = root;
                }

                // Update the entire tree's Root if necessary
                if (isTreeRoot)
                {
                    pivot.Tree.Root = pivot;
                }

                // Update the original parent's child node
                if (isLeftChild)
                {
                    rootParent.LeftChild = pivot;
                }
                else
                {
                    if (rootParent != null)
                    {
                        rootParent.RightChild = pivot;
                    }
                }
            }
        }

        /// <summary>
        /// Rotates a node to the right within an AVL Tree
        /// </summary>
        protected virtual void RotateRight(AVLTreeNode<T> root)
        {
            if (root == null)
            {
                return;
            }

            AVLTreeNode<T> pivot = root.LeftChild;

            if (pivot == null)
            {
                return;
            }
            else
            {
                // Original parent of root node
                AVLTreeNode<T> rootParent = root.Parent;

                // Whether the root was the parent's left node
                bool isLeftChild = (rootParent != null) && rootParent.LeftChild == root;

                // Whether the root was the root of the entire tree
                bool makeTreeRoot = root.Tree.Root == root; 

                // Rotate
                root.LeftChild = pivot.RightChild;
                pivot.RightChild = root;

                // Update parents
                root.Parent = pivot;
                pivot.Parent = rootParent;

                if (root.LeftChild != null)
                {
                    root.LeftChild.Parent = root;
                }

                // Update the entire tree's Root if necessary
                if (makeTreeRoot)
                {
                    pivot.Tree.Root = pivot;
                }

                // Update the original parent's child node
                if (isLeftChild)
                {
                    rootParent.LeftChild = pivot;
                }
                else
                {
                    if (rootParent != null)
                    {
                        rootParent.RightChild = pivot;
                    }
                }
            }
        }
    }
}