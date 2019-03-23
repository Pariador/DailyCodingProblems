class BinNode<T>
{
    public BinNode(T value, BinNode<T> left = null, BinNode<T> right = null)
    {
        this.Value = value;
        this.Left = left;
        this.Right = right;
    }

    public T Value { get; }

    public BinNode<T> Left { get; set; }

    public BinNode<T> Right { get; set; }

    public override string ToString()
    {
        return this.Value.ToString();
    }
}