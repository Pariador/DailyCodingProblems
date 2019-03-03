using System;
using System.IO;

static class Program
{
    private const string File = "data.txt";

    private static readonly Random Random = new Random();

    static void Main(string[] args)
    {
        const int LineLength = 20;
        const string NewLine = "\r\n";

        int getLinesCount = 30;
        if (args.Length > 0)
        {
            getLinesCount = int.Parse(args[0]);
        }

        Console.WriteLine($"Getting {getLinesCount} random lines from {File}...");
        for (int i = 0; i < getLinesCount; i++)
        {
            string line = GetRandomLine(out int lineNumber);
            Console.WriteLine($"{lineNumber.ToString("d3")}: {line}");
        }
    }

    // Given known stream length.
    static string GetRandomLine(int lineLength, string newLine, out int lineNumber)
    {
        lineLength += newLine.Length;

        var reader = new StreamReader("data.txt");

        int byteCount = reader.CurrentEncoding.GetByteCount("a");
        int charCount = (int)(reader.BaseStream.Length) / byteCount;

        // Assuming file contents are trimmed.
        int lineCount = (charCount + newLine.Length) / (lineLength);

        lineNumber = Random.Next(1, lineCount + 1);
        string line = "";
        for (int i = 1; i <= lineNumber; i++)
        {
            line = reader.ReadLine();
        }

        reader.Dispose();

        return line;
    }

    // Given unknown stream length.
    static string GetRandomLine(out int lineNumber)
    {
        var reader = new StreamReader("data.txt");

        lineNumber = -1;
        string line = "";
        int maxRandom = -1;

        int number = 1;
        for (string next = reader.ReadLine(); next != null; next = reader.ReadLine(), number++)
        {
            int random = Random.Next();

            if (random > maxRandom)
            {
                maxRandom = random;
                lineNumber = number;
                line = next;
            }
        }

        reader.Dispose();

        return line;
    }
}