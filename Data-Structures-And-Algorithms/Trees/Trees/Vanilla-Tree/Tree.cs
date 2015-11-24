namespace Vanilla_Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Tree<T>
        where T : IComparable<T>
    {
        private TreeNode<T> root;
        private int size;

        public Tree(T value)
            : this(new TreeNode<T>(value))
        {
        }

        public Tree(TreeNode<T> root)
        {
            this.Root = root;
        }

        public Tree(T value, params TreeNode<T>[] children)
            : this(value)
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

        public void TraverseBFSWithQueue()
        {
        	// Инициализираш структура от данни тип опашка в която ще слагаме обходените елементи.
            Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();
            
            // Поставяш корена в опашката.
            queue.Enqueue(this.root);

            while (queue.Count > 0)
            {
            	// Възел от дървото който съхранява изплют елемент от опашката който ще обработваме(принтираме в случая)
                TreeNode<T> currentNode = queue.Dequeue();

                Console.Write("{0} ", currentNode.Value);

				// Добавяме итеративно в опашката всички деца на елемента (currentNode), който преди малко изплюхме от опашката.
                for (int i = 0; i < currentNode.ChildrenCount; i++)
                {
                    TreeNode<T> childNode = currentNode.GetChild(i);
                    queue.Enqueue(childNode);
                }
                
                // При първоначално влизане в цикъла, в опашката имаме само root-a (queue.Count == 1), 
                // изплюли сме root елемента в променливата currentNode принтирали сме го и сме добавили неговите 3 деца в опашката.
            	// На второто завъртане в цикъла в опашката имаме 3 елемента(децата на root-a), вадим първия елемент, взимаме и неговите деца(нека приемем, че са 2) и ги слагаме в опашката
				// В началото на третото завъртане, в опашката ни ще има следната наредба от елементи rootChild2<--rootChild3<--(първото дете на rootChild2)<--(второто дете на rootChild2).
				// А принтираните досега елементи са root, rootChild1, които вече не са в опашката защото на предните 2 стъпки сме ги изкарали и обработили.
			}
        }

