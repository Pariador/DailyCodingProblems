namespace Problem08
{
    class Node<T>
    {
        public Node(T value, Node<T> left = null, Node<T> right = null)
        {
            this.Value = value;
            this.Left = left;
            this.Right = right;
        }

        public T Value { get; }

        public Node<T> Left { get; }

        public Node<T> Right { get; }
    }
}