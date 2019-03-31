using System;

static class Program
{
    static readonly Random Random = new Random();

    static void Main()
    {
        int[] numbers = new int[28];

        for (int i = 0; i < numbers.Length; i++)
        {
            numbers[i] = Rand7();
        }

        Console.WriteLine("Random numbers 1 - 7:");
        Console.WriteLine(string.Join(", ", numbers));
    }

    static int Rand7()
    {
        int number;
        do
        {
            number = ((Rand5() - 1) * 5) + Rand5();
        } while (21 < number);

        return number % 7 + 1;
    }

    static int Rand5()
    {
        return Random.Next(1, 6);
    }
}