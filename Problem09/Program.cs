namespace Problem09
{
    using System;
    using System.Linq;

    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers;
            if (args.Length > 0)
            {
                numbers = args.Select(int.Parse)
                    .ToArray();
            }
            else
            {
                numbers = new int[] { 2, 4, 6, 2, 5 };
            }

            Console.WriteLine("Numbers:");
            Console.WriteLine(string.Join(", ", numbers));

            int max = FindMaxSumOfSeparate(numbers);

            Console.WriteLine($"\nMax sum of separate numbers: {max}");
        }

        static int FindMaxSumOfSeparate(int[] numbers)
        {
            if (numbers.Length == 0)
            {
                return 0;
            }

            int maxSumInclusive = numbers[0];
            int maxSumExclusive = 0;

            for (int i = 1; i < numbers.Length; i++)
            {
                int newExclusive = Math.Max(maxSumInclusive, maxSumExclusive);

                maxSumInclusive = maxSumExclusive + numbers[i];
                maxSumExclusive = newExclusive;
            }

            return Math.Max(maxSumInclusive, maxSumExclusive);
        }
    }
}