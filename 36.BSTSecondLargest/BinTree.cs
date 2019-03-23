using System;

class BinTree<T> where T : IComparable<T>
{
    private BinNode<T> root;

    public int Count { get; private set; }

    public void Add(T value)
    {
        var node = this.Find(value, out int location);

        if (node != null && location == 0)
        {
            return;
        }

        if (node == null)
        {
            this.root = new BinNode<T>(value);
        }
        else if (location < 0)
        {
            node.Left = new BinNode<T>(value);
        }
        else if (0 < location)
        {
            node.Right = new BinNode<T>(value);
        }

        this.Count++;
    }

    private BinNode<T> Find(T value, out int location)
    {
        location = 0;
        if (root == null)
        {
            return null;
        }

        BinNode<T> current = null;
        BinNode<T> next = root;
        do
        {
            current = next;

            location = value.CompareTo(current.Value);
            if (location == 0)
            {
                return current;
            }
            else if (location < 0)
            {
                next = current.Left;
            }
            else
            {
                next = current.Right;
            }
        } while (next != null);

        return current;
    }

    public T FindBiggest()
    {
        var biggest = FindBiggest(this.root, out BinNode<T> prev);

        if (biggest == null)
        {
            throw new ArgumentException("Tree is empty!");
        }

        return biggest.Value;
    }

    public T FindSecondBiggest()
    {
        if (this.Count < 2)
        {
            throw new ArgumentException("Tree has less than 2 elements.");
        }

        var biggest = FindBiggest(this.root, out BinNode<T> prev);

        if (biggest.Left != null)
        {
            return FindBiggest(biggest.Left, out prev).Value;
        }

        return prev.Value;
    }

    private static BinNode<T> FindBiggest(BinNode<T> root, out BinNode<T> prev)
    {
        prev = null;
        if (root == null)
        {
            return root;
        }

        var current = root;
        while (current.Right != null)
        {
            prev = current;
            current = current.Right;
        }

        return current;
    }
}