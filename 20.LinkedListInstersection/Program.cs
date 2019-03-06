using System;

class Program
{
    private static readonly Random Random = new Random();

    static void Main()
    {
        var suffix = new ListNode<int>(8);
        suffix.Next = new ListNode<int>(10);

        var first = RandomList();
        var second = RandomList();

        first.Next = suffix;
        second.Next = suffix;

        ListNode<int> intersection = FindIntersection(first, second);

        if (intersection == null)
        {
            Console.WriteLine("No intersection.");
        }
        else
        {
            Console.WriteLine($"Intersection at: {intersection.Value}");
        }
    }

    static ListNode<int> RandomList()
    {
        const int Min = 0;
        const int Max = 5001;
        const int MinLength = 1;
        const int MaxLength = 101;

        var first = new ListNode<int>(Random.Next(Min, Max));

        int length = Random.Next(MinLength, MaxLength);

        var current = first;
        for (int i = 0; i < length - 1; i++)
        {
            current.Next = new ListNode<int>(Random.Next(Min, Max));

            current = current.Next;
        }

        return first;
    }

    static ListNode<int> FindIntersection(ListNode<int> first, ListNode<int> second)
    {
        int firstLength = first.Length();
        int secondLength = second.Length();

        if (firstLength > secondLength)
        {
            int diff = firstLength - secondLength;
            for (int i = 0; i < diff; i++)
            {
                first = first.Next;
            }
        }
        else
        {
            int diff = secondLength - firstLength;
            for (int i = 0; i < diff; i++)
            {
                second = second.Next;
            }
        }

        while (first != second)
        {
            first = first.Next;
            second = second.Next;
        }

        return first;
    }
}