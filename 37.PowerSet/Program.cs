using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static void Main()
    {
        int[] set = { 1, 2, 3, 4 };

        int[][] powerset = Powerset(set);

        string output = Format(powerset.Select(Format));

        Console.WriteLine("Powerset of {0}:", Format(set));
        Console.WriteLine(output);
    }

    static string Format<T>(IEnumerable<T> array)
    {
        return "{" + string.Join(", ", array) + "}";
    }

    static int[][] Powerset(int[] set)
    {
        var powerset = new List<int[]>();

        int full = (1 << set.Length) - 1;
        for (int ss = 0; ss <= full; ss++)
        {
            powerset.Add(GetSubset(set, ss));
        }

        return powerset.ToArray();
    }

    static int[] GetSubset(int[] set, int subset)
    {
        var result = new List<int>();

        for (int i = 0; i < set.Length; i++)
        {
            if (GetBit(subset, i))
            {
                result.Add(set[i]);
            }
        }

        return result.ToArray();
    }

    static bool GetBit(int number, int i)
    {
        return ((number >> i) & 1) == 1;
    }
}