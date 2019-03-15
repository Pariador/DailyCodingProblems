using System;
using System.Text;

static class Program
{
    static void Main()
    {
        string str = "AAAAAAAAAABBBCCDAA";

        string encoded = Encode(str);
        string decoded = Decode(encoded);

        Console.WriteLine($"String: {str}");
        Console.WriteLine($"Encoded: {encoded}");
        Console.WriteLine($"Decoded: {decoded}");
        Console.WriteLine("Decode: {0}", str == decoded ? "SUCCESS" : "FAIL");
    }

    static string Encode(string str)
    {
        var result = new StringBuilder();

        for (int i = 0; i < str.Length;)
        {
            char @char = str[i];
            int count = 0;

            while (i < str.Length && str[i] == @char)
            {
                count++;
                i++;
            }

            result.Append(count);
            result.Append(@char);
        }

        return result.ToString();
    }

    static string Decode(string str)
    {
        var result = new StringBuilder();

        for (int i = 0, numLength; i < str.Length; i++)
        {
            numLength = 0;
            while (char.IsDigit(str[i + numLength]))
                numLength++;

            int count = int.Parse(str.Substring(i, numLength));

            i += numLength;

            result.Append(new string(str[i], count));
        }

        return result.ToString();
    }
}