namespace Problem17
{
    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;

    static class Program
    {
        static void Main(string[] args)
        {
            string fileStructure = File.ReadAllText("file_structure.txt");
            fileStructure = fileStructure.Replace("\r\n", "\n");
            fileStructure = fileStructure.Replace("\r", "\n");

            Console.WriteLine("File structure:");
            Console.WriteLine(fileStructure);

            Directory dir = ParseDir(fileStructure);

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

        static Directory ParseDir(string str)
        {
            string[] nodes = str.Split('\n');

            return ParseDir(nodes, out int end);
        }

        static Directory ParseDir(string[] nodes, out int end, int index = 0)
        {
            end = index;

            if (index < 0 || nodes.Length <= index)
            {
                return null;
            }

            int depth = CountPreTabs(nodes[index]);
            string name = nodes[index].Trim();

            Directory dir = new Directory(name);
            if (index == nodes.Length - 1)
            {
                return dir;
            }

            for (int i = index + 1; i < nodes.Length; i++)
            {
                int nodeDepth = CountPreTabs(nodes[i]);
                if (depth >= nodeDepth)
                {
                    break;
                }

                if (nodes[i].Contains('.'))
                {
                    dir.Files.Add(nodes[i].Trim());
                }
                else
                {
                    dir.Directories.Add(ParseDir(nodes, out i, i));
                }

                end = i;
            }

            return dir;
        }

        static int CountPreTabs(string str)
        {
            int count = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (str[i] == '\t')
                {
                    count++;
                }
                else 
                {
                    break;
                }
            }

            return count;
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