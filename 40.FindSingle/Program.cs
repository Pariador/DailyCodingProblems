using System;

static class Program
{
    static void Main()
    {
        int[][] sets = 
        { 
            new int[] { 6, 1, 3, 3, 3, 6, 6 },
            new int[] { 13, 19, 13, 13 },
            new int[] { 1, 2, 3, 4, 5, 6, 5, 5, 4, 4, 6, 1, 2, 2, 1, 6 },
        };

        foreach (var set in sets)
        {
            Console.WriteLine($"Set: {string.Join(" ", set)}");

            int single = FindSingle(set);

           Console.WriteLine($"Single: {single}\n");
        }
    }

    static int FindSingle(int[] numbers)
    {
        /* The 1s of all numbers except the single will be repeated thrice.
           The program detects thrice repeated 1s, and removes them, leaving
           just the single.
        */
        int odd = 0; // Holds bits repeated an odd amount of times.
        int even = 0; // Holds bits repeated an even amount of times.

        for (int i = 0; i < numbers.Length; i++)
        {
            // Save even bits.
            even |= odd & numbers[i];

            // Save odd bits, or remove even bits.
            odd ^= numbers[i];

            // Bits that are in even and reappear in odd, are thrice repeated.
            int thriceRepeated = odd & even;

            // Remove trice repeated bits.
            odd &= ~thriceRepeated;
            even &= ~thriceRepeated;
        }

        return odd;
    }
}