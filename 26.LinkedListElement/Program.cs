using System;

static class Program
{
    static void Main()
    {
        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        Console.WriteLine("Numbers:");
        Console.WriteLine(string.Join(" ", numbers));
        Console.WriteLine();

        var first = ToList(numbers);

        for (int i = 1; i <= numbers.Length; i++)
        {
            int last = CountLastElement(first, i);

            Console.WriteLine("Element {0:d2} from end: {1:d2}", i, last);
        }
    }
    
    static T CountLastElement<T>(ListNode<T> first, int count)
    {
        var head = first;
        var tail = first;

        for (int i = 0; i < count - 1; i++)
        {
            head = head.Next;
        }

        while (head.Next != null)
        {
            head = head.Next;
            tail = tail.Next;
        }

        return tail.Value;
    }

    static ListNode<int> ToList(params int[] array)
    {
        var first = new ListNode<int>(array[0]);

        var current = first;
        for (int i = 1; i < array.Length; i++)
        {
            current.Next = new ListNode<int>(array[i]);

            current = current.Next;
        }

        return first;
    }
}