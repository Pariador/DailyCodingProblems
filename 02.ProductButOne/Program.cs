using System;
using System.Linq;

static class Program
{
    static void Main(string[] args)
    {
        int[] numbers = new int[] { 1, 2, 3, 4, 5 };

        if (args.Length != 0)
        {
            numbers = args.Select(int.Parse).ToArray();
        }

        Console.WriteLine("Numbers:");
        Console.WriteLine(string.Join(", ", numbers));

        int[] result = ProductButOne(numbers);

        Console.WriteLine("\nWith division:");
        Console.WriteLine(string.Join(", ", result));

        result = ProductButOne2(numbers);

        Console.WriteLine("\nWithout division:");
        Console.WriteLine(string.Join(", ", result));
    }

    // With division.
    static int[] ProductButOne(int[] numbers)
    {
        int product = numbers.Aggregate(1, (partial, number) => partial * number);

        int[] result = new int[numbers.Length];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = product / numbers[i];
        }

        return result;
    }

    // Without division.
    static int[] ProductButOne2(int[] numbers)
    {
        int[] result = new int[numbers.Length];

        for (int i = 0; i < result.Length; i++)
        {
            result[i] = 1;
        }

        for (int i = 0; i < result.Length; i++)
        {
            for (int j = 0; j < result.Length; j++)
            {
                if (i != j)
                {
                    result[i] *= numbers[j];
                }
            }
        }

        return result;
    }
}