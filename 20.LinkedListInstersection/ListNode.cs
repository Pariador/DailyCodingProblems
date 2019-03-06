class ListNode<T>
{
    public ListNode(T value, ListNode<T> next = null)
    {
        this.Value = value;
        this.Next = next;
    }

    public T Value { get; }

    public ListNode<T> Next { get; set; }

    public int Length()
    {
        int length = 1;

        ListNode<T> current = this.Next;
        while (current != null)
        {
            length++;

            current = current.Next;
        }

        return length;
    }
}