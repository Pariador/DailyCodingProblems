using System;
using System.Collections.Generic;
using System.Text;

enum Operation
{
    Replace,
    Insert,
    Delete
}

static class Program
{
    static void Main()
    {
        string from = "DEVELOPER";
        string to = "ENVELOPED";
        var costs = new Dictionary<Operation, double>()
        {
            { Operation.Replace, 1.0 },
            { Operation.Insert, 0.8 },
            { Operation.Delete, 0.9 },
        };

        double med = MinEditDistance(from, to, costs);

        Console.WriteLine($"From: {from}");
        Console.WriteLine($"To:   {to}");
        Console.WriteLine($"Minimum edit distance: {med}");
    }

    static double MinEditDistance(string from, string to, Dictionary<Operation, double> costs)
    {
        double[,] distances = new double[from.Length + 1, to.Length + 1];

        for (int t = 1; t <= to.Length; t++)
            distances[0, t] = distances[0, t - 1] + costs[Operation.Insert];

        for (int f = 1; f <= from.Length; f++)
            distances[f, 0] = distances[f - 1, 0] + costs[Operation.Delete];

        for (int f = 1; f <= from.Length; f++)
        {
            for (int t = 1; t <= to.Length; t++)
            {
                double replaceCost = distances[f - 1, t - 1];

                if (from[f - 1] != to[t - 1])
                    replaceCost += costs[Operation.Replace];

                double insertCost = distances[f, t - 1] + costs[Operation.Insert];
                double deleteCost = distances[f - 1, t] + costs[Operation.Delete];

                distances[f, t] = Math.Min(replaceCost, Math.Min(insertCost, deleteCost));
            }
        }

        return distances[from.Length, to.Length];
    }

    static void Print(double[,] matrix)
    {
        Func<double, string> format = d => d.ToString().PadLeft(3, '0');

        var result = new StringBuilder();

        for (int row = 0; row < matrix.GetLength(0); row++)
        {
            result.Append(format(matrix[row, 0]));

            for (int col = 1; col < matrix.GetLength(1); col++)
                result.Append(" " + format(matrix[row, col]));

            result.AppendLine();
        }

        Console.Write(result.ToString());
    }
}