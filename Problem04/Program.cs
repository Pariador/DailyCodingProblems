namespace Problem04
{
    using System;
    using System.Linq;

    static class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = null;
            if (args.Length == 0)
            {
                numbers = new int[] { 3, 4, -1, 1 };
            }
            else
            {
                numbers = args.Select(int.Parse)
                    .ToArray();
            }

            Console.WriteLine("Numbers:");
            Console.WriteLine(string.Join(",", numbers));

            int minPositive = FindMinPositiveExcept(numbers);

            Console.WriteLine($"\nMin positive interger not in numbers: {minPositive}");
        }

        static int FindMinPositiveExcept(int[] numbers)
        {
            int positiveLength = Segragate(numbers);

            for (int i = 0; i < positiveLength; i++)
            {
                int index = Math.Abs(numbers[i]) - 1;
                if (index < positiveLength)
                {
                    numbers[index] = -Math.Abs(numbers[index]);
                }
            }

            for (int i = 0; i < positiveLength; i++)
            {
                if (numbers[i] > 0)
                {
                    return i + 1;
                }
            }

            return positiveLength + 1;
        }

        static int Segragate(int[] numbers)
        {
            int i = 0;
            for (int n = numbers.Length - 1; i <= n; i++)
            {
                if (numbers[i] <= 0)
                {
                    int hold = numbers[n];
                    numbers[n] = numbers[i];
                    numbers[i] = hold;

                    n--;
                    i--;
                }
            }

            return i;
        }
    }
}