namespace Autocomplete
{
    using System.Collections.Generic;
    using System.Linq;

    public class Trie
    {
        private TrieNode root;

        public Trie()
        {
            this.root = new TrieNode("");
        }

        public Trie(IEnumerable<string> words)
            : this()
        {
            foreach (var word in words)
            {
                this.Add(word);
            }
        }

        public void Add(string str)
        {
            TrieNode current = this.root;
            for (int i = 0; i < str.Length; i++)
            {
                if (!current.Children.ContainsKey(str[i]))
                {
                    current.Children[str[i]] = new TrieNode();
                }

                current = current.Children[str[i]];
            }

            current.Value = str;
        }

        public bool Contains(string str)
        {
            return this.Find(str) != null;
        }

        public string[] Match(string prefix) 
        {
            TrieNode start = this.Find(prefix);
            if (start == null)
            {
                return new string[0];

            }

            var matches = new List<string>();

            var stack = new Stack<TrieNode>();
            stack.Push(start);

            while (stack.Any())
            {
                TrieNode current = stack.Pop();
                if (current.Value != null)
                {
                    matches.Add(current.Value);
                }

                foreach (var pair in current.Children)
                {
                    stack.Push(pair.Value);
                }
            }

            return matches.ToArray();
        }

        private TrieNode Find(string str)
        {
            TrieNode current = this.root;
            for (int i = 0; i < str.Length; i++)
            {
                if (current.Children.ContainsKey(str[i]))
                {
                    current = current.Children[str[i]];
                }
                else
                {
                    return null;
                }
            }

            return current;
        }
    }
}