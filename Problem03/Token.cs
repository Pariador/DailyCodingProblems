namespace Problem03
{
    class Token
    {
        public static Token Parse(string str)
        {
            string[] data = str.Split(':');

            return new Token(data[0], int.Parse(data[1]));
        }

        public Token(string value, int depth)
        {
            this.Value = value;
            this.Depth = depth;
        }

        public string Value { get; }
        
        public int Depth { get; }

        public override string ToString()
        {
            return $"Value: {this.Value} | Depth: {this.Depth}";
        }
    }
}