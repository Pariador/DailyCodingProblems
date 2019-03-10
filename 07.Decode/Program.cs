using System;
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

    static int CountDecodes(string message)
    {
        int[] solutions = new int[message.Length + 1];
        solutions[0] = 1;

        string[] codes = GetCodes();

        for (int p = 1; p <= message.Length; p++)
        {
            foreach (var code in codes)
            {
                int prev = p - code.Length;

                if (0 <= prev && solutions[prev] != -1 && Match(code, message, prev))
                {
                    solutions[p] += solutions[prev];
                }
            }
        }

        return solutions[message.Length];
    }

    static bool Match(string word, string str, int i)
    {
        if (i < 0 || str.Length - i < word.Length)
        {
            return false;
        }

        for (int w = 0; w < word.Length; w++)
        {
            if (word[w] != str[i + w])
            {
                return false;
            }
        }

        return true;
    }
}