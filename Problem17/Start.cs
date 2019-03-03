namespace Problem17
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    static class Start
    {
        static void Main(string[] args)
        {
            string fileStructure = File.ReadAllText("file_structure.txt");

            Console.WriteLine("File structure:");
            Console.WriteLine(fileStructure);

            Token[] tokens = Token.Tokenize(fileStructure);

            Directory dir = ParseDir(new Queue<Token>(tokens));

            var paths = GetFilePaths(dir);

            string longest = Longest(paths);

            Console.WriteLine("\nLongest file path:");
            Console.WriteLine(longest);
        }

        static string[] GetFilePaths(Directory dir, string path = "")
        {
            path += dir.Name + "/";

            string[] filePaths = new string[dir.Files.Count];

            for (int i = 0; i < filePaths.Length; i++)
            {
                filePaths[i] = path + dir.Files[i];
            }

            foreach (var subdir in dir.Directories)
            {
                filePaths = filePaths.Concat(GetFilePaths(subdir, path))
                    .ToArray();
            }

            return filePaths;
        }

        static Directory ParseDir(Queue<Token> tokens)
        {
            Token token = tokens.Dequeue();
            if (token.IsFile)
            {
                throw new ArgumentException("Token isn't a directory!");
            }

            Directory dir = new Directory(token.Name);

            while (tokens.Any() && token.Depth < tokens.Peek().Depth)
            {
                if (tokens.Peek().IsFile)
                {
                    dir.Files.Add(tokens.Dequeue().Name);
                }
                else
                {
                    dir.Directories.Add(ParseDir(tokens));
                }
            }

            return dir;
        }

        static string Longest(IEnumerable<string> strings)
        {
            string max = "";

            foreach (var str in strings)
            {
                if (max.Length < str.Length)
                {
                    max = str;
                }
            }

            return max;
        }
    }
}