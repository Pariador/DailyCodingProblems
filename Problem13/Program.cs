namespace Problem13
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

    static class Program
    {
        static void Main(string[] args)
        {
            string str = "abcba";
            int charCount = 2;

            if (args.Length >= 1)
            {
                str = args[0];
                charCount = int.Parse(args[1]);
            }

            Console.WriteLine($"String: {str}");
            Console.WriteLine($"Character count: {charCount}");

            string longest = LongestSubsequence(str, charCount);

            Console.WriteLine($"\nLongest substring given {charCount} characters:");
            Console.WriteLine(longest);
        }

        static string LongestSubsequence(string str, int charCount)
        {
            char[] longestSequence = new char[0];

            var sequence = new LinkedList<char>();
            var occurances = new Dictionary<char, int>();

            for (int i = 0; i < str.Length; i++)
            {
                if (!occurances.ContainsKey(str[i]))
                {
                    occurances[str[i]] = 0;
                }

                if (occurances[str[i]] == 0)
                {
                    if (charCount > 0)
                    {
                        charCount--;
                    }
                    else
                    {
                        FreeUpChar(sequence, occurances);
                    }
                }

                sequence.AddLast(str[i]);
                occurances[str[i]]++;

                if (sequence.Count > longestSequence.Length)
                {
                    longestSequence = sequence.ToArray();
                }
            }

            return new string(longestSequence);
        }

        static void FreeUpChar(LinkedList<char> sequence, Dictionary<char, int> occurances)
        {
            char @char;
            do
            {
                @char = sequence.First.Value;

                sequence.RemoveFirst();
                occurances[@char]--;

            } while (occurances[@char] != 0);
        }
    }
}