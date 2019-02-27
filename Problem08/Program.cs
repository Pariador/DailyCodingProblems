namespace Problem08
{
    using System;

    static class Program
    {
        static void Main(string[] args)
        {
            Node<int> root = new Node<int>
            (
                0,
                new Node<int>(1),
                new Node<int>
                (
                    0,
                    new Node<int>
                    (
                        1,
                        new Node<int>(1),
                        new Node<int>(1)
                    ),
                    new Node<int>(0)
                )
            );

            int univalCount = CountUnivalTrees(root, out bool isUnival);

            Console.WriteLine($"Unival trees count: {univalCount}");
            Console.WriteLine($"Is tree unival: {isUnival}");
        }

        static int CountUnivalTrees<T>(Node<T> root, out bool isUnival)
        {
            isUnival = false;

            if (root == null)
            {
                isUnival = true;
                return 0;
            }
            else if (root.Left == null && root.Right == null)
            {
                isUnival = true;
                return 1;
            }

            int leftUnivalCount = CountUnivalTrees(root.Left, out bool isLeftUnival);
            int rightUnivalCount = CountUnivalTrees(root.Right, out bool isRightUnival);

            int univalCount = leftUnivalCount + rightUnivalCount;

            if ((isLeftUnival && isRightUnival) &&
                (root.Value.Equals(root.Left.Value) && root.Value.Equals(root.Right.Value)))
            {
                isUnival = true;
                univalCount++;
            }

            return univalCount;
        }
    }
}