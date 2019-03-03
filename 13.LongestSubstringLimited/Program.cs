using System;
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

        string longest = LongestSubstring(str, charCount);

        Console.WriteLine($"\nLongest substring given {charCount} characters:");
        Console.WriteLine(longest);
    }

    static string LongestSubstring(string str, int charCount)
    {
        int maxStart = 0;
        int maxLength = 0;

        int start = 0;
        int length = 0;
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
                    // free up character
                    char @char;
                    do
                    {
                        @char = str[start];

                        start++;
                        length--;

                        occurances[@char]--;

                    } while (occurances[@char] != 0);
                }
            }

            length++;
            occurances[str[i]]++;

            if (length > maxLength)
            {
                maxStart = start;
                maxLength = length;
            }
        }

        return str.Substring(maxStart, maxLength);
    }
}