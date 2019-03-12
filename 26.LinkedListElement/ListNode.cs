class ListNode<T>
{
    public ListNode(T value, ListNode<T> next = null)
    {
        this.Value = value;
        this.Next = next;
    }

    public T Value { get; }

    public ListNode<T> Next { get; set; }
}