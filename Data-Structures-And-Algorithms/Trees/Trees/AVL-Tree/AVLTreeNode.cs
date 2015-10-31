namespace Trees.AVLTree
{
    using System;

    public class AVLTreeNode<T> : BinaryTreeNode<T>
        where T : IComparable
    {
        public AVLTreeNode(T value)
            : base(value)
        {
        }

        public new AVLTreeNode<T> Parent
        {
            get
            {
                return (AVLTreeNode<T>)base.Parent;
            }
            set
            {
                base.Parent = value;
            }
        }

        public new AVLTreeNode<T> LeftChild
        {
            get
            {
                return (AVLTreeNode<T>)base.LeftChild;
            }
            set
            {
                base.LeftChild = value;
            }
        }

        public new AVLTreeNode<T> RightChild
        {
            get
            {
                return (AVLTreeNode<T>)base.RightChild;
            }
            set
            {
                base.RightChild = value;
            }
        }
    }
}
