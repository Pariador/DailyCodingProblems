using System;
using System.Linq;

static class Program
{
    static void Main(string[] args)
    {
        int steps = 4;
        int[] increments = { 1, 2 };

        if (args.Length >= 2)
        {
            steps = int.Parse(args[0]);
            increments = args.Skip(1)
                .Select(int.Parse)
                .ToArray();
        }

        Console.WriteLine($"Steps: {steps}");
        Console.WriteLine($"Increments: {string.Join(", ", increments)}");

        int climbs = CountClimbs(steps, increments);

        Console.WriteLine($"\nNumber of possible climbs: {climbs}");
    }

    static int CountClimbs(int steps, int[] increments)
    {
        int[] solutions = new int[steps + 1];
        solutions[0] = 1;

        for (int s = 1; s < solutions.Length; s++)
        {
            int solution = 0;

            for (int i = 0; i < increments.Length; i++)
            {
                int prev = s - increments[i];
                if (prev >= 0)
                {
                    solution += solutions[prev];
                }
            }

            solutions[s] = solution;
        }


        return solutions[steps];
    }
}