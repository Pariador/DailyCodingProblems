using System;
using System.Linq;

static class Program
{
    static readonly Random Random = new Random();

    static void Main()
    {
        const int Count = 15;

        var heap = new MaxHeap<int>();

        Print(heap);

        Console.WriteLine($"Pushing {Count} numbers...");
        for (int i = 0; i < Count; i++)
        {
            int num = Random.Next(1, 100);

            Console.WriteLine($"push {num}");
            heap.Push(num);

            Print(heap);
            Console.WriteLine();
        }

        Console.WriteLine("------------------------------------------------");

        Print(heap);

        Console.WriteLine($"\nPoping {Count} numbers...");
        while (heap.Any())
        {
            Console.WriteLine($"pop {heap.Pop()}");
            Print(heap);
            Console.WriteLine();
        }

    }

    static void Print(MaxHeap<int> heap)
    {
        Console.WriteLine($"Heap ({heap.Count}):");
        Console.WriteLine(string.Join(" ", heap));
    }
}