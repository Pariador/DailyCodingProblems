namespace TreeSerialization
{
    using System;

    static class Start
    {
        static void Main(string[] args)
        {
            Node root = new Node("root", new Node("left", new Node("left.left")), new Node("right"));

            Console.WriteLine("Before serialization:");
            Print(root);

            string tree = Serialization.Serialize(root);
            Console.WriteLine("\nSerialized:");
            Console.WriteLine(tree);

            Node after = Serialization.Desirialize(tree);
            Console.WriteLine("\nDesirialized:");
            Print(after);
        }

        static void Traverse(Node node, Action<Node, int> action, int depth = 0)
        {
            if (node == null)
            {
                return;
            }

            action(node, depth);
            Traverse(node.Left, action, depth + 1);
            Traverse(node.Right, action, depth + 1);
        }

        static void Print(Node node)
        {
            Traverse(node, (n, d) => Console.WriteLine("{0}--{1}", n.Value, d));
        }
    }
}