namespace TreeSerialization
{
    class Node
    {
        public Node(string value, Node left = null, Node right = null)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }

        public string Value { get; }

        public Node Left { get; }

        public Node Right { get; }
    }
}