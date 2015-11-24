namespace Vanilla_Tree
{
    public class Startup
    {
        public static void Main()
        {
            var tree = new Tree<string>(
                new TreeNode<string>("Root"),
                    new TreeNode<string>("Music"),
                    new TreeNode<string>("Pictures",
                        new TreeNode<string>("Miami",
                            new TreeNode<string>("Landscape.jpg"),
                            new TreeNode<string>("Seaside.jpg"),
                            new TreeNode<string>("Restaurant.jpg"))),
                    new TreeNode<string>("Documents"));

            tree.TraverseDFS();
        }
    }
}
