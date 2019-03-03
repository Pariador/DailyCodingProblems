using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static void Main(string[] args)
    {
        string message = "12132436";
        if (args.Any())
        {
            message = args[0];
        }

        int decodesCount = CountDecodes(message);

        Console.WriteLine($"Possible decodes: {decodesCount}");
    }

    static string[] GetCodes()
    {
        string[] codes = new string[26];

        for (int i = 0; i < codes.Length; i++)
        {
            codes[i] = (i + 1).ToString();
        }

        return codes;
    }

    // This repeats computations. Needs to be optimized.
    static int CountDecodes(string message)
    {
        int decodesCount = 0;

        string[] codes = GetCodes();

        int[] partials = { 0 };
        List<int> next = new List<int>();

        while (partials.Any())
        {
            for (int p = 0; p < partials.Length; p++)
            {
                for (int c = 0; c < codes.Length; c++)
                {
                    int length = codes[c].Length % (message.Length - partials[p] + 1);

                    string part = message.Substring(partials[p], length);
                    if (part == codes[c])
                    {
                        int newPartial = partials[p] + codes[c].Length;
                        if (newPartial >= message.Length)
                        {
                            decodesCount++;
                            continue;
                        }

                        next.Add(newPartial);
                    }
                }
            }
            partials = next.ToArray();
            next.Clear();
        }

        return decodesCount;
    }
}