namespace Problem11
{
    using System.Collections.Generic;

    class TrieNode
    {
        public TrieNode(string value = null)
        {
            this.Value = value;
            this.Children = new Dictionary<char, TrieNode>();
        }

        public string Value { get; set; }

        public Dictionary<char, TrieNode> Children { get; }
    }
}