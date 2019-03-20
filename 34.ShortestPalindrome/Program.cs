using System;
using System.Linq;
using System.Text;

static class Program
{
    static void Main()
    {
        string[] words =
        {
            "race",
            "google",
            "googoogle",
            "AACECAAAA"
        };

        foreach (var word in words)
        {
            string shortest = ShortestPalindrome(word);

            Console.WriteLine($"Word: {word}");
            Console.WriteLine($"Shortest palindrome: {shortest}\n");
        }
    }

    static string ShortestPalindrome(string word)
    {
        string firstPalindromized = null;
        int longestSubpalindrome = 0;

        for (int i = 0; i < word.Length; i++)
        {
            for (int j = i; j < word.Length; j++)
            {
                int len = j - i + 1;
                if (IsPalindrome(word, i, len) && longestSubpalindrome <= len)
                {
                    longestSubpalindrome = len;

                    string palindromized = Palindromize(word, i, len);

                    if 
                    (
                        firstPalindromized == null ||
                        palindromized.Length < firstPalindromized.Length ||
                        palindromized.CompareTo(firstPalindromized) < 0
                    )
                        firstPalindromized = palindromized;
                }
            }
        }

        return firstPalindromized;
    }

    static string Palindromize(string word, int start = 0, int length = 1)
    {
        if (word == null || word.Length == 0)
            return word;

        start %= word.Length;
        start = start < 0 ? word.Length + start : start;

        int lengthLeft = word.Length - start;

        if (length <= 0)
            return word;

        length = ((length - 1) % lengthLeft) + 1;

        var result = new StringBuilder();

        string core = word.Substring(start, length);
        string prefix = word.Substring(0, start);
        string suffix = word.Substring(start + length);

        result.Append(prefix);
        result.Append(suffix.Reverse().ToArray());
        result.Append(core);
        result.Append(suffix);
        result.Append(prefix.Reverse().ToArray());

        return result.ToString();
    }

    static bool IsPalindrome(string word, int start = 0, int length = -1)
    {
        if (word.Length == 0)
            return true;

        start %= word.Length;
        start = start < 0 ? word.Length + start : start;

        int lengthLeft = word.Length - start;

        if (length < 0)
            length = lengthLeft;

        if (length == 0)
            return true;

        length = ((length - 1) % lengthLeft) + 1;

        int halfLen = length / 2;
        int middle = start + halfLen;
        int leftOffset = 0;
        if (length % 2 == 0)
        {
            if (word[middle] != word[middle - 1])
                return false;
            leftOffset = 1;
        }

        for (int i = 0; i < halfLen - leftOffset; i++)
        {
            int left = middle - leftOffset - 1 - i;
            int right = middle + 1 + i;

            if (word[left] != word[right])
            {
                return false;
            }
        }

        return true;
    }
}
