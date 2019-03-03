using System;
using System.Linq;
using System.Collections.Generic;

static class Program
{
    static void Main(string[] args)
    {
        int[] numbers = { 10, 15, 3, 7 };
        int sum = 17;

        if (args.Length >= 2)
        {
            numbers = args.Skip(1)
                .Select(int.Parse)
                .ToArray();

            sum = int.Parse(args[0]);
        }

        Console.WriteLine($"Numbers: {string.Join(", ", numbers)}");

        bool result = IsSumPossible(numbers, sum);

        Console.WriteLine($"\nDo 2 of the numbers sum to {sum}: {result}");
    }

    static bool IsSumPossible(int[] numbers, int sum)
    {
        var required = new HashSet<int>();

        for (int i = 0; i < numbers.Length; i++)
        {
            if (required.Contains(numbers[i]))
            {
                return true;
            }

            required.Add(sum - numbers[i]);
        }

        return false;
    }
}