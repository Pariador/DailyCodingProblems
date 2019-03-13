using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

static class Program
{
    const char AnyChar = '.';
    const char AnyCount = '*';

    static void Main()
    {
        string pattern = "b.*t";
        string[] strs =
        {
            "bet",
            "bot",
            "but",
            "nut",
            "bettttttt",
            "be",
            "bt",
        };

        Console.WriteLine($"Pattern: {pattern}\n");

        for (int i = 0; i < strs.Length; i++)
        {
            string result = Match(pattern, strs[i]) ? "MATCH" : "NO MATCH";

            Console.WriteLine($"{strs[i]}: {result}");
        }
    }

    static bool Match2(string pattern, string str)
    {
        for (int p = 0, s = 0; p < pattern.Length; p++)
        {
            char symbol = str[s] == AnyChar ? '\0' : str[s];
            int count = 1;
            if (p < pattern.Length - 1 && pattern[p + 1] == AnyCount)
            {
                count = -1;
                p++;
            }

            // TODO: Apply {char, count} tokenization.
            // TODO: Unlimited count = lengthLeft - tokensLeft
        }

        return true;
    }

    static bool Match(string pattern, string str)
    {
        int p = 0;
        int s = 0;
        while (p < pattern.Length || s < str.Length)
        {
            if (pattern.Length <= p || pattern.Length <= s)
            {
                return false;
            }

            if (p < pattern.Length - 1 && pattern[p + 1] == AnyCount)
            {
                char end = '\0';

                bool match = false;
                while (s < str.Length && (str[s] == pattern[p - 1] || pattern[p - 1] == AnyChar))
                {
                    match = true;
                    s++;
                }

                if (!match)
                {
                    s--;
                }

                p++;
            }
            else if (pattern[p] != str[s] && pattern[p] != AnyChar)
            {
                return false;
            }
            

            p++;
            s++;
        }

        return true;
    }
}