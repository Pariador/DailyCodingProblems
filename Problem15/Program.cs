namespace Problem15
{
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
                string line = GetRandomLine(LineLength, NewLine, out int lineNumber);
                Console.WriteLine($"{lineNumber.ToString("d3")}: {line}");
            }
        }

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
    }
}