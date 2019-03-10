using System;
using System.Linq;
using System.Collections.Generic;

static class Program
{
    static void Main()
    {
        string str = "thequickbrownfox";
        string[] words = { "the", "quick", "brown", "fox" };
        Run(words, str);

        str = "bedbathandbeyond";
        words = new string[] { "bed", "bath", "bedbath", "and", "beyond", "tha", "ba", "nd" };
        Run(words, str);
    }

    static void Run(string[] words, string str)
    {
        Console.WriteLine($"Text: {str}");
        Console.WriteLine($"Words: {string.Join(", ", words)}");

        string[] sentences = Reconstruct(words, str);

        Console.WriteLine("\nSentences:");
        foreach (var sentence in sentences)
        {
            Console.WriteLine(sentence);
        }

        Console.WriteLine();
    }

    static string[] Reconstruct(string[] words, string str)
    {
        var solutions = new Dictionary<int, List<string[]>>();
        solutions[0] = new List<string[]>();
        solutions[0].Add(new string[0]);

        for (int p = 1; p <= str.Length; p++)
        {
            foreach (var word in words)
            {
                int rest = p - word.Length;

                if (!solutions.ContainsKey(rest) || !Match(word, str, rest))
                {
                    continue;
                }

                if (!solutions.ContainsKey(p))
                {
                    solutions[p] = new List<string[]>();
                }

                foreach (var partial in solutions[rest])
                {
                    solutions[p].Add(partial.Concat(new string[] { word }).ToArray());
                }
            }
        }

        if (!solutions.ContainsKey(str.Length))
        {
            return new string[0];
        }

        return solutions[str.Length].Select(s => string.Join(" ", s))
            .ToArray();
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