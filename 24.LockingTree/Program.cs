using System;

static class Program
{
    static void Main()
    {
        var root = GetTree();
        Print(root, "Initial:");

        bool res = root.Left.Lock();
        Print(root, $"\nLeft lock: {res}");

        res = root.Right.Lock();
        Print(root, $"\nRight lock: {res}");

        res = root.Lock();
        Print(root, $"\nRoot lock: {res}");

        res = root.Left.Unlock();
        Print(root, $"\nLeft unlock: {res}");

        res = root.Right.Unlock();
        Print(root, $"\nRight unlock: {res}");

        res = root.Lock();
        Print(root, $"\nRoot lock: {res}");

        res = root.Right.Lock();
        Print(root, $"\nRight lock: {res}");

        res = root.Unlock();
        Print(root, $"\nRoot unlock: {res}");

        LockLeaves(root);
        Print(root, $"\nLeaves lock:");

        LockLeaves(root);
        Print(root, $"\nLeaves lock 2:");

        UnlockLeaves(root);
        Print(root, $"\nLeaves unlock:");
    }

    static void LockLeaves(Node<string> node)
    {
        if (node == null)
        {
            return;
        }

        if (node.Left == null && node.Right == null)
        {
            node.Lock();
        }
        else
        {
            LockLeaves(node.Left);
            LockLeaves(node.Right);
        }
    }

    static void UnlockLeaves(Node<string> node)
    {
        if (node == null)
        {
            return;
        }

        if (node.Left == null && node.Right == null)
        {
            node.Unlock();
        }
        else
        {
            UnlockLeaves(node.Left);
            UnlockLeaves(node.Right);
        }
    }

    static void Print(Node<string> node, string title)
    {
        Console.WriteLine(title);
        Print(node);
    }

    static void Print(Node<string> node)
    {
        if (node == null)
        {
            return;
        }

        string locked = node.Locked ? "locked" : "unlocked";

        string name = node.Value.PadRight(24, ' ');
        locked = locked.PadLeft(8, ' ');

        Console.WriteLine($"{name} | {locked} | {node.LockedDescendants}");

        Print(node.Left);
        Print(node.Right);
    }

    static Node<string> GetTree()
    {
        var root = new Node<string>
        (
            value: "root",
            left: new Node<string>
            (
                value: "root.left",
                left: new Node<string>
                (
                    value: "root.left.left",
                    left: null,
                    right: null
                ),
                right: new Node<string>
                (
                    value: "root.left.right",
                    left: new Node<string>
                    (
                        value: "root.left.right.left",
                        left: null,
                        right: null
                    ),
                    right: null
                )
            ),
            right: new Node<string>
            (
                value: "root.right",
                left: new Node<string>
                (
                    value: "root.right.left",
                    left: null,
                    right: null
                ),
                right: new Node<string>
                (
                    value: "root.right.right",
                    left: null,
                    right: new Node<string>
                    (
                        value: "root.right.right.right",
                        left: null,
                        right: null
                    )
                )
            )
        );

        return root;
    }
}