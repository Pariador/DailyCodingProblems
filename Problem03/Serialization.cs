namespace Problem03
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    static class Serialization
    {
        private const char Separator = ':';

        public static string Serialize(Node node)
        {
            StringBuilder builder = new StringBuilder();

            Serialize(node, builder);

            return builder.ToString().Trim();
        }

        private static void Serialize(Node node, StringBuilder builder, int depth = 0)
        {
            if (node == null)
            {
                return;
            }

            builder.AppendLine($"{node.Value}{Separator}{depth}");

            Serialize(node.Left, builder, depth + 1);
            Serialize(node.Right, builder, depth + 1);
        }

        public static Node Desirialize(string str)
        {
            var tokens = new Queue<Token>(str.Split('\n').Select(s => Token.Parse(s.Trim())));

            return Deserialize(tokens);
        }

        private static Node Deserialize(Queue<Token> tokens, int depth = 0)
        {
            if (!tokens.Any() || tokens.Peek().Depth != depth)
            {
                return null;
            }

            Token token = tokens.Dequeue();

            return new Node
            (
                value: token.Value,
                left: Deserialize(tokens, depth + 1),
                right: Deserialize(tokens, depth + 1)
            );
        }
    }
}