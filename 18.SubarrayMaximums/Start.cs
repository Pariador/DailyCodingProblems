using System;
using System.Linq;

using static Solutions;

static class Start
{
    static void Main(string[] args)
    {
        int subarrayLength = 3;
        int[] numbers = { 10, 5, 2, 7, 8, 7 };

        if (args.Length >= 2)
        {
            subarrayLength = int.Parse(args[0]);
            numbers = args.Skip(1)
                .Select(int.Parse)
                .ToArray();
        }

        int[] results = ImprovedInsertionSort(numbers, 3);

        Console.WriteLine(string.Join(", ", results));
    }
}