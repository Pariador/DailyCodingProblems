using System;

static class Program
{
    static void Main()
    {
        int[][] sets =
        {
            new int[] { 8, 10, 14, 13, 3, 1, 6, 4, 7 },
            new int[] { 50, 76, 54, 72, 67, 17, 9, 23, 14, 19, 12 },
            new int[] { 60, 74, 65, 70, 63, 62, 64, 41, 16, 53, 25, 46, 55, 42 },
            new int[] { 5, 3, 8, 2, 4, 1, 6, 7 },
        };

        foreach (var set in sets)
        {
            var tree = new BinTree<int>();

            foreach (var number in set)
            {
                tree.Add(number);
            }

            int bigest = tree.FindBiggest();
            int secondBigest = tree.FindSecondBiggest();

            Console.WriteLine("Numbers:");
            Console.WriteLine(string.Join(" ", set));
            Console.WriteLine($"Biggest: {bigest}");
            Console.WriteLine($"Second bigest: {secondBigest}\n");
        }
    }
}