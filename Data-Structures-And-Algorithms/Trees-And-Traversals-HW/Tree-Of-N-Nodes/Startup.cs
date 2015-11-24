namespace Tree_Of_N_Nodes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;

    public class Startup
    {
        private static List<string> nodes = new List<string>();

        public static void Main()
        {
            var inputPairs = new int[11, 2]
            {
                {2, 4},
                {3, 2},
                {3, 5},
                {5, 0},
                {5, 6},
                {5, 1},
                {1, 10},
                {10, 11},
                {11, 14},
                {3, 50},
                {4, 21 }
            };

            var rows = inputPairs.GetLength(0);
            var cols = inputPairs.GetLength(1);

            var parentNodes = new HashSet<int>();
            var childNodes = new HashSet<int>();

            for (int i = 0; i < rows; i++)
            {
                parentNodes.Add(inputPairs[i, 0]);

                for (int j = 1; j < cols; j++)
                {
                    childNodes.Add(inputPairs[i, j]);
                }
            }

            // The difference between the parents and the children sets is used for finding the root (element without parent)
            var roots = parentNodes.Except(childNodes);

            // The difference between the children and the parents set is used for finding all the leafs (elements without children)
            var leafs = childNodes.Except(parentNodes);

            // The Intersection between parent and child nodes gives us all the nodes of the tree
            // The Difference between all nodes and (root + leafs) gives us the inner nodes of the tree
            var innerNodes = parentNodes.Intersect(childNodes).Except(roots.Intersect(leafs));

            Print(roots, "Root");
            Console.WriteLine(new String('=', 60));

            Print(innerNodes, "Inner Node");
            Console.WriteLine(new String('=', 60));

            Print(leafs, "Leaf");
            Console.WriteLine(new String('=', 60));

            var nodesWithChildren = new Dictionary<int, List<int>>();

            for (int i = 0; i < rows; i++)
            {
                var key = inputPairs[i, 0];

                if (!nodesWithChildren.ContainsKey(key))
                {
                    nodesWithChildren.Add(key, new List<int>());
                }

                for (int j = 1; j < cols; j++)
                {
                    var child = inputPairs[i, j];

                    nodesWithChildren[key].Add(child);
                }
            }

            foreach (var item in nodesWithChildren)
            {
                Console.Write("Parent: {0} --> Children: ", item.Key);

                foreach (var value in item.Value)
                {
                    Console.Write("{0}, ", value);
                }

                Console.WriteLine();
            }

            Console.WriteLine(new String('=', 60));

            var tree = BuildTree(nodesWithChildren, 3);
            var longestPathLength = nodes.Max(x => x.Length);
            var longestPathString = nodes.Find(x => x.Length == longestPathLength);

            Console.WriteLine("Longest path: {0} ", longestPathString);

            Console.WriteLine(new String('=', 60));

            PrintPathsFromRootOnConditionEqual(30);

            Console.WriteLine(new String('=', 60));

            PrintPathsFromSubtreesOnConditionEqual(25);

            Console.WriteLine(new String('=', 60));
        }

        private static void Print(IEnumerable<int> collection, string itemName)
        {
            if (itemName.Equals("Root"))
            {
                // If there is only 1 element that has no parents - this is our root
                if (collection.Count() == 1)
                {
                    Console.WriteLine("{0} -> {1} ", itemName, collection.FirstOrDefault());
                }

                // If there is more than 1 element that has no parents - we had an invalid input
                else
                {
                    throw new ArgumentException("Invalid input.");
                }
            }
            else
            {
                foreach (var item in collection)
                {
                    Console.WriteLine("{0} -> {1} ", itemName, item);
                }
            }
        }

        public class TreeNode<T>
        {
            public List<TreeNode<T>> children = new List<TreeNode<T>>();
            public T thisItem;
            public TreeNode<T> parent;
        }

        public static TreeNode<T> BuildTree<T>(Dictionary<T, List<T>> dictionary, T root)
        {
            var newTree = new TreeNode<T>
            {
                thisItem = root,
            };

            newTree.children = GetChildNodes(dictionary, newTree);

            return newTree;
        }

        public static List<TreeNode<T>> GetChildNodes<T>(Dictionary<T, List<T>> dictionary, TreeNode<T> parent)
        {
            var nodeList = new List<TreeNode<T>>();

            if (dictionary.ContainsKey(parent.thisItem))
            {
                foreach (var item in dictionary[parent.thisItem])
                {
                    var nodeToAdd = new TreeNode<T>
                    {
                        thisItem = item,
                        parent = parent,
                    };

                    if (!ContainedInParent(parent, item))
                    {
                        nodeToAdd.children = GetChildNodes(dictionary, nodeToAdd);
                    }

                    // output leaf node for debugging!
                    if (nodeToAdd.children.Count == 0)
                    {
                        var nodePathToString = NodeString(nodeToAdd);
                        nodes.Add(nodePathToString);
                    }

                    nodeList.Add(nodeToAdd);
                }
            }

            return nodeList;
        }

        private static string NodeString<T>(TreeNode<T> node)
        {
            return (node.parent != null ? NodeString(node.parent) + "--->" : string.Empty) + node.thisItem;
        }

        private static bool ContainedInParent<T>(TreeNode<T> parent, T item)
        {
            var found = false;

            if (parent != null)
            {
                if (parent.thisItem.Equals(item))
                {
                    found = true;
                }
                else
                {
                    found = ContainedInParent(parent.parent, item);
                }
            }

            return found;
        }

        private static List<int> ExtractAllValuesFromNodeStringPath(string path)
        {
            var list = new List<int>();
            var matches = Regex.Matches(path, "[0-9]+");

            foreach (var item in matches)
            {
                list.Add(int.Parse(item.ToString()));
            }

            return list;
        }

        private static int SumNodes(string path)
        {
            var values = ExtractAllValuesFromNodeStringPath(path);

            return values.Sum();
        }

        private static void PrintPathsFromRootOnConditionEqual(int targetSum)
        {
            foreach (var path in nodes)
            {
                var sum = SumNodes(path);

                if (sum == targetSum)
                {
                    Console.WriteLine("Full Paths with sum equal to {0} -> {1} ", targetSum, path);
                }
            }
        }

        private static void PrintPathsFromSubtreesOnConditionEqual(int targetSum)
        {
            foreach (var path in nodes)
            {
                var workPath = path;

                while (workPath.IndexOf("--->") != -1)
                {
                    workPath = workPath.Substring(workPath.IndexOf("--->") + 4);

                    var sum = SumNodes(workPath);

                    if (sum == targetSum)
                    {
                        Console.WriteLine("Path with sum equal to {0} -> {1} ", targetSum, workPath);
                    }

                }
            }
        }
    }
}
