namespace Trees.AVLTree
{
    using System;

    /// <summary>
    /// A Binary Tree node that holds an element and references to other tree nodes
    /// </summary>
    public class BinaryTreeNode<T>
        where T : IComparable
    {
        private T data;
        private BinaryTree<T> tree;
        private BinaryTreeNode<T> parent;
        private BinaryTreeNode<T> leftChild;
        private BinaryTreeNode<T> rightChild;

        /// <summary>
        /// Create a new instance of a Binary Tree node
        /// </summary>
        public BinaryTreeNode(T data)
        {
            this.data = data;
        }

        /// <summary>
        /// The value of the data stored at the node
        /// </summary>
        public virtual T Value
        {
            get { return this.data; }
            set { this.data = value; }
        }

        /// <summary>
        /// Gets or sets the left child node
        /// </summary>
        public virtual BinaryTreeNode<T> LeftChild
        {
            get { return this.leftChild; }
            set { this.leftChild = value; }
        }

        /// <summary>
        /// Gets or sets the right child node
        /// </summary>
        public virtual BinaryTreeNode<T> RightChild
        {
            get { return this.rightChild; }
            set { this.rightChild = value; }
        }

        /// <summary>
        /// Gets or sets the parent node
        /// </summary>
        public virtual BinaryTreeNode<T> Parent
        {
            get { return this.parent; }
            set { this.parent = value; }
        }

        /// <summary>
        /// Gets or sets the Binary Tree the node belongs to
        /// </summary>
        public virtual BinaryTree<T> Tree
        {
            get { return this.tree; }
            set { this.tree = value; }
        }

        /// <summary>
        /// Gets whether the node is a leaf (has no children)
        /// </summary>
        public virtual bool IsLeaf
        {
            get { return this.ChildsCount == 0; }
        }

        /// <summary>
        /// Gets whether the node is internal (has children nodes)
        /// </summary>
        public virtual bool IsInternal
        {
            get { return this.ChildsCount > 0; }
        }

        /// <summary>
        /// Gets whether the node is the left child of its parent
        /// </summary>
        public virtual bool IsLeftChild
        {
            get { return this.Parent != null && this.Parent.LeftChild == this; }
        }

        /// <summary>
        /// Gets whether the node is the right child of its parent
        /// </summary>
        public virtual bool IsRightChild
        {
            get { return this.Parent != null && this.Parent.RightChild == this; }
        }

        /// <summary>
        /// Gets the number of children this node has
        /// </summary>
        public virtual int ChildsCount
        {
            get
            {
                int count = 0;

                if (this.LeftChild != null)
                {
                    count++;
                }

                if (this.RightChild != null)
                {
                    count++;
                }

                return count;
            }
        }

        /// <summary>
        /// Gets whether the node has a left child node
        /// </summary>
        public virtual bool HasLeftChild
        {
            get { return (this.LeftChild != null); }
        }

        /// <summary>
        /// Gets whether the node has a right child node
        /// </summary>
        public virtual bool HasRightChild
        {
            get { return (this.RightChild != null); }
        }
    }
}