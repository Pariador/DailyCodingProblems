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
        var complete = new List<string>();

        var partials = new List<string[]>();
        partials.Add(new string[0]);

        var next = new List<string[]>();
        while (partials.Any())
        {
            foreach (var partial in partials)
            {
                int partialLength = partial.Sum(word => word.Length);

                foreach (var word in words)
                {
                    if (Match(word, str, partialLength))
                    {
                        string[] @new = partial.Concat(new string[] { word })
                            .ToArray();

                        if (partialLength + word.Length == str.Length)
                        {
                            complete.Add(string.Join(" ", @new));
                        }
                        else
                        {
                            next.Add(@new);
                        }
                    }
                }
            }

            var hold = partials;
            partials = next;
            next = hold;
            next.Clear();
        }

        return complete.ToArray();
    }

    static bool Match(string word, string str, int i)
    {
        if (str.Length - i < word.Length)
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