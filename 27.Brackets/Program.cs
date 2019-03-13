using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    private const string Open = "([{";
    private const string Close = ")]}";

    static void Main()
    {
        string[] inputs =
        {
            "([])[]({})",
            "([)]",
            "((()",
            "]",
            "][",
            "]{)(}[",
            "(word)",
            "(word",
            "word)",
            ")word(",
        };

        foreach (var input in inputs)
        {
            string result = Balanced(input) ? "balanced" : "unbalanced";

            Console.WriteLine($"Text: {input}");
            Console.WriteLine($"Brackets are {result}.\n");
        }
    }

    static bool Balanced(string str)
    {
        var opened = new Stack<char>();

        for (int i = 0; i < str.Length; i++)
        {
            if (Open.Contains(str[i]))
            {
                opened.Push(str[i]);
                continue;
            }

            int closeType = Close.IndexOf(str[i]);
            if (closeType != -1)
            {
                if (!opened.Any() ||
                    Open.IndexOf(opened.Peek()) != closeType)
                {
                    return false;
                }

                opened.Pop();
            }
        }

        return !opened.Any();
    }
}