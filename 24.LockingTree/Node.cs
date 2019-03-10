class Node<T>
{
    private Node<T> left;

    private Node<T> right;

    public Node(T value, Node<T> left = null, Node<T> right = null)
    {
        this.Value = value;
        this.Left = left;
        this.Right = right;

        this.Locked = false;
        this.SetLockedDescendatns();
    }

    public T Value { get; }

    public Node<T> Left 
    {
        get
        {
            return this.left;
        }
        set
        {
            if (this.left != null)
            {
                this.left.Parent = null;
            }

            if (value != null)
            {
                if (value.Parent != null)
                {
                    value.Parent.RemoveChild(value);
                }

                value.Parent = this;
            }

            this.left = value;

            this.SetLockedDescendatns();
        }
    }

    public Node<T> Right
    {
        get
        {
            return this.right;
        }
        set
        {
            if (this.right != null)
            {
                this.right.Parent = null;
            }

            if (value != null)
            {
                if (value.Parent != null)
                {
                    value.Parent.RemoveChild(value);
                }

                value.Parent = this;
            }

            this.right = value;

            this.SetLockedDescendatns();
        }
    }

    public Node<T> Parent { get; private set; }

    public bool Locked { get; private set; }

    public int LockedDescendants { get; private set; }

    public bool Lock()
    {
        if (this.Locked || !this.IsLockModifiable())
        {
            return false;
        }

        this.Locked = true;
        this.AdjustAncestor(true);

        return true;
    }

    public bool Unlock()
    {
        if (!this.Locked || !this.IsLockModifiable())
        {
            return false;
        }

        this.Locked = false;
        this.AdjustAncestor(false);

        return true;
    }

    private bool IsLockModifiable()
    {
        if (this.LockedDescendants > 0)
        {
            return false;
        }

        var current = this.Parent;
        while (current != null)
        {
            if (current.Locked)
            {
                return false;
            }

            current = current.Parent;
        }

        return true;
    }

    private void SetLockedDescendatns()
    {
        int count = 0;

        if (this.Left != null)
        {
            count += this.Left.LockedDescendants;
            if (this.Left.Locked)
                count++;
        }

        if (this.Right != null)
        {
            count += this.Right.LockedDescendants;
            if (this.Right.Locked)
                count++;
        }

        this.LockedDescendants = count;
    }

    private void AdjustAncestor(bool locked)
    {
        int mod = locked ? +1 : -1;

        for (var current = this.Parent; current != null; current = current.Parent)
        {
            current.LockedDescendants += mod;
        }
    }

    private bool RemoveChild(Node<T> node)
    {
        if (this.left == node)
        {
            this.left = null;
            return true;
        }
        else if (this.right == node)
        {
            this.right = null;
            return true;
        }

        return false;
    }

    public override string ToString()
    {
        return this.Value.ToString();
    }
}