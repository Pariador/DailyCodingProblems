namespace Problem11
{
    using System;
    using System.IO;

    static class Program
    {
        static void Main(string[] args)
        {
            string query = args.Length > 0 ? args[0] : "de";

            string[] words = File.ReadAllLines("words.txt");

            Trie trie = new Trie(words);

            string[] matches = trie.Match(query);

            if (matches.Length > 0)
            {
                Console.WriteLine("Matches:");
                foreach (var match in matches)
                {
                    Console.WriteLine(match);
                }
            }
            else
            {
                Console.WriteLine("No matches.");
            }
        }
    }   
}