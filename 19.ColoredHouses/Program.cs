using System;
using System.Linq;

static class Program
{
    private static readonly Random Random = new Random();

    static void Main()
    {
        int[,] costs = new int[,]
        {
            { 3, 4, 2 },
            { 7, 9, 1 },
            { 3, 11, 14 },
            { 1, 5, 9 },
            { 2, 15, 17 },
        };

        int lowest = LowestTotalCost(costs);

        Console.WriteLine($"Lowest total cost: {lowest}");
    }

    static int LowestTotalCost(int[,] costs)
    {
        int houseCount = costs.GetLength(0);
        int colorCount = costs.GetLength(1);

        int[] totals = new int[colorCount];

        int[] next = new int[colorCount];
        for (int h = 0; h < houseCount; h++)
        {
            int min = Min2(totals, out int min2);

            for (int c = 0; c < next.Length; c++)
            {
                next[c] = (totals[c] == min ? min2 : min) + costs[h, c];
            }

            int[] hold = totals;
            totals = next;
            next = hold;
        }

        return totals.Min();
    }

    static int Min2(int[] numbers, out int min2)
    {
        if (numbers.Length < 2)
        {
            throw new ArgumentException("Need at least 2 numbers!");
        }

        int min;
        if (numbers[0] < numbers[1])
        {
            min = numbers[0];
            min2 = numbers[1];
        }
        else
        {
            min = numbers[1];
            min2 = numbers[0];
        }

        for (int i = 2; i < numbers.Length; i++)
        {
            if (numbers[i] < min)
            {
                min2 = min;
                min = numbers[i];
            }
        }

        return min;
    }
}