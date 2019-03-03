namespace FindLongestFilePath
{
    using System.Linq;

    class Token
    {
        public static Token[] Tokenize(string str)
        {
            str = str.Replace("\r\n", "\n");
            str = str.Replace("\r", "\n");

            string[] data = str.Split('\n');

            Token[] tokens = data.Select(Token.Parse).ToArray();

            return tokens;
        }

        public static Token Parse(string str)
        {
            return new Token
            (
                name: str.Trim(),
                depth: CountPreTabs(str),
                isFile: str.Contains('.')
            );
        }

        private static int CountPreTabs(string str)
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

        public Token(string name, int depth, bool isFile = true)
        {
            this.Name = name;
            this.Depth = depth;
            this.IsFile = isFile;
        }

        public string Name { get; }

        public int Depth { get; }

        public bool IsFile { get; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}