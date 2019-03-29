using System;
using System.Collections;
using System.Collections.Generic;

class MaxHeap<T> : IEnumerable<T>
    where T : IComparable<T>
{
    private static int Left(int i)
    {
        return i * 2 + 1;
    }

    private static int Right(int i)
    {
        return i * 2 + 2;
    }

    private static int Parent(int i)
    {
        return i == 0 ? -1 : (i - 1) / 2;
    }

    private List<T> items;

    public MaxHeap()
    {
        this.items = new List<T>();
    }

    public MaxHeap(IEnumerable<T> items)
        : this()
    {
        foreach (var item in items)
        {
            this.Push(item);
        }
    }

    public int Count
    {
        get
        {
            return this.items.Count;
        }
    }

    public void Push(T item)
    {
        this.items.Add(item);

        int i = this.items.Count - 1;
        int parent = Parent(i);
        while (parent >= 0)
        {
            if (this.items[i].CompareTo(this.items[parent]) > 0)
            {
                this.items.Swap(i, parent);
            }
            else
            {
                break;
            }

            i = parent;
            parent = Parent(i);
        }
    }

    public T Pop()
    {
        if (this.items.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty!");
        }

        T top = this.items[0];

        int last = this.items.Count - 1;

        this.items[0] = this.items[last];
        this.items.RemoveAt(last);

        int i = 0;
        int left = Left(i);
        int right = Right(i);
        bool hasLeft = left < this.items.Count;
        bool hasRight = right < this.items.Count;
        while (hasLeft || hasRight)
        {
            int max;
            if (hasLeft && hasRight)
            {
                max = this.items[left].CompareTo(this.items[right]) < 0 ? right : left;
            }
            else if (hasLeft)
            {
                max = left;
            }
            else
            {
                max = right;
            }

            if (this.items[i].CompareTo(this.items[max]) < 0)
            {
                this.items.Swap(i, max);
                i = max;
            }
            else
            {
                break;
            }

            left = Left(i);
            right = Right(i);
            hasLeft = left < this.items.Count;
            hasRight = right < this.items.Count;
        }

        return top;
    }

    public T Peek()
    {
        if (this.items.Count == 0)
        {
            throw new InvalidOperationException("Heap is empty!");
        }

        return items[0];
    }

    public IEnumerator<T> GetEnumerator()
    {
        return this.items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return this.GetEnumerator();
    }
}