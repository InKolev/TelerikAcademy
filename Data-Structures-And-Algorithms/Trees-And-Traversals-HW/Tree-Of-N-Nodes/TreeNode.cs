using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tree_Of_N_Nodess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class TreeNode<T>
        where T : IComparable<T>
    {
        private T value;
        private bool hasParent;
        private TreeNode<T> parent;
        private List<TreeNode<T>> children;

        private Comparer<T> comparer;

        public TreeNode(TreeNode<T> parent, T value)
        {
            if (parent == null)
            {
                this.HasParent = false;
            }
            else
            {
                this.Parent = parent;
                this.HasParent = true;
            }

            this.Children = new List<TreeNode<T>>();
            this.Value = value;
        }

        public TreeNode(TreeNode<T> parent, T value, params TreeNode<T>[] children)
            : this(parent, value)
        {
            foreach (var child in children)
            {
                this.Children.Add(child);
            }
        }

        public T Value
        {
            get { return this.value; }
            private set { this.value = value; }
        }

        public bool HasParent
        {
            get { return this.hasParent; }
            private set { this.hasParent = value; }
        }

        public int ChildrenCount
        {
            get { return this.Children.Count; }
        }

        public TreeNode<T> Parent
        {
            get { return this.parent; }
            private set { this.parent = value; }
        }

        public List<TreeNode<T>> Children
        {
            get { return this.children; }
            private set { this.children = value; }
        }

        /// <summary>
        /// Adds a new children containing the specified value to the successors list.
        /// </summary>
        /// <param name="value">The value which will be hold by the successor node.</param>
        public void AddChild(T value)
        {
            this.InitializeChildrenListIfNecessary();

            var node = new TreeNode<T>(null, value);

            this.AddChild(node);
        }

        /// <summary>
        /// Adds a new child node to the successors list.
        /// </summary>
        /// <param name="node">The node to be added.</param>
        public void AddChild(TreeNode<T> child)
        {
            if (child == null)
            {
                return;
            }

            this.InitializeChildrenListIfNecessary();

            this.Children.Add(child);
        }

        public bool Remove(T value)
        {
            if (this.Children == null)
            {
                return false;
            }

            bool isMatch = false;

            foreach (var child in this.Children)
            {
                if (this.comparer.Compare(child.Value, value) == 0)
                {
                    isMatch = true;

                    this.Children.Remove(child);
                }
            }

            if (isMatch)
            {
                return true;
            }
            else
            {
                foreach (var child in this.Children)
                {
                    var isRemoved = child.Remove(value);

                    if (isRemoved)
                    {
                        break;
                    }
                }
            }

            return false;
        }

        public TreeNode<T> GetChild(int index)
        {
            return this.Children[index];
        }

        private void InitializeChildrenListIfNecessary()
        {
            if (this.Children == null)
            {
                this.Children = new List<TreeNode<T>>();
            }
        }
    }
}
