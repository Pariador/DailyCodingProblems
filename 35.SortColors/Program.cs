using System;
using System.Collections.Generic;

static class Program
{
    const char Red = 'R';
    const char Green = 'G';
    const char Blue = 'B';

    static readonly Random Random = new Random();
    static readonly Dictionary<int, char> ToColor = new Dictionary<int, char>() 
    {
        { 0, 'R' },
        { 1, 'G' },
        { 2, 'B' },
    };

    static void Main()
    {   
        char[] colors = { 'G', 'B', 'R', 'R', 'B', 'R', 'G' };

        colors = RandomColors();

        Console.WriteLine("UNSORTED:");
        Console.WriteLine(string.Join(" ", colors));

        SortColors(colors);

        Console.WriteLine("\nSORTED:");
        Console.WriteLine(string.Join(" ", colors));
    }

    static char[] SortColors(char[] colors)
    {
        int red = 0;
        int blue = colors.Length - 1;
        for (int i = 0; i <= blue;)
        {
            if (colors[i] == Red || colors[i] == Green)
            {
                if (colors[i] == Red)
                {
                    colors.Swap(i, red);
                    red++;
                }

                i++;
            }
            else if (colors[i] == Blue)
            {
                colors.Swap(i, blue);
                blue--;
            }

        }

        return colors;
    }

    static T[] Swap<T>(this T[] array, int first, int second)
    {
        T hold = array[first];
        array[first] = array[second];
        array[second] = hold;

        return array;
    }

    static char[] RandomColors(int count = 30)
    {
        char[] colors = new char[30];

        for (int i = 0; i < count; i++)
        {
            colors[i] = ToColor[Random.Next(0, 3)];
        }

        return colors;
    }
}