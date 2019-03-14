using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static void Main()
    {
        int width = 16;
        string text = "the quick brown fox jumps over the lazy dog";

        string[] words = GetWords(text);

        var lines = Justify(words, width);

        string[] result = JoinLines(lines, width);

        Console.WriteLine($"Line width: {width}");
        Console.WriteLine("Text:");
        Console.WriteLine(text);

        Console.WriteLine("\nJustified:");
        foreach (var line in result)
        {
            Console.WriteLine(line);
        }
    }

    static string[] GetWords(string text)
    {
        string[] boundries =
        {
            "\r\n",
            "\n",
            "\r",
            " ",
            "\t",
        };

        return text.Split(boundries, StringSplitOptions.RemoveEmptyEntries);
    }

    static string[][] Justify(string[] words, int width)
    {
        Result[] results = new Result[words.Length + 1];

        results[words.Length] = new Result(0, 0, 0, 0);

        for (int i = words.Length - 1; i >= 0; i--)
        {
            for (int end = i + 1; end <= words.Length; end++)
            {
                int wordCount = end - i;

                Result line = new Result
                (
                    lineStart: i,
                    wordCount: wordCount,
                    totalQuality: LineQuality(words, width, i, wordCount) + results[end].TotalQuality,
                    lineCount: results[end].LineCount + 1
                );

                if (results[i] == null || results[i].AverageQuality() <= line.AverageQuality())
                {
                    results[i] = line;
                }
            }
        }

        return GetLines(words, results);
    }

    static double LineQuality(string[] words, int width, int start, int wordCount)
    {
        int lineLength = 0;
        for (int i = start, len = start + wordCount; i < len; i++)
        {
            lineLength += words[i].Length;
        }

        lineLength += wordCount - 1;

        if (lineLength > width)
        {
            return int.MinValue;
        }

        return (double)lineLength / width;
    }

    static string[][] GetLines(string[] words, Result[] results)
    {
        int w = 0;
        var lines = new List<string[]>();
        while (w < words.Length)
        {
            string[] line = new string[results[w].WordCount];

            for (int i = 0; i < line.Length; i++, w++)
            {
                line[i] = words[w];
            }

            lines.Add(line);
        }

        return lines.ToArray();
    }

    static string[] JoinLines(string[][] lines, int width)
    {
        string[] result = new string[lines.Length];

        for (int i = 0; i < lines.Length; i++)
        {
            if (2 <= lines[i].Length)
            {
                int spacedWords = lines[i].Length - 1;
                int length = lines[i].Select(word => word.Length).Sum() + spacedWords;

                int totalPadding = width - length;
                int perWord = totalPadding / spacedWords;
                int remainder = totalPadding % spacedWords;

                for (int w = 0; w < spacedWords; w++)
                {
                    int padding = perWord;
                    if (0 < remainder)
                    {
                        padding++;
                        remainder--;
                    }

                    lines[i][w] = lines[i][w] + new string(' ', padding);
                }
            }

            result[i] = string.Join(" ", lines[i]);
        }

        return result;
    }
}