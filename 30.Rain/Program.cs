using System;

static class Program
{
    static void Main()
    {
        int[][] maps =
        {
            new int[] { 2, 1, 2 },
            new int[] { 3, 0, 1, 3, 0, 5 },
            new int[] { 3, 0, 0, 2, 0, 4 },
            new int[] { 3, 0, 0, 2, 0, 4, 0, 2, 0, 0, 3 }
        };

        foreach (var map in maps)
        {
            Console.WriteLine("Map:");
            Console.WriteLine(string.Join(" ", map));

            int rain = Rain(map);
            Console.WriteLine($"Rain: {rain}\n");
        }
    }

    static int Rain(int[] map)
    {
        int rain = 0;
        int i = 0;
        while (i < map.Length)
        {
            int decline = FindDecline(map, i);
            if (decline == -1)
            {
                break;
            }

            int end = FindNextClosestPeek(map, decline);
            if (end == -1)
            {
                break;
            }


            int max = Math.Min(map[decline], map[end]);

            for (int j = decline + 1; j < end; j++)
            {
                rain += max - map[j];
            }

            i = end;
        }

        return rain;
    }

    static int FindDecline(int[] map, int start)
    {
        for (int i = start; i < map.Length - 2; i++)
        {
            if (map[i] > map[i + 1])
            {
                return i;
            }
        }

        return -1;
    }

    static int FindIncline(int[] map, int start)
    {
        for (int i = start; i < map.Length - 1; i++)
        {
            if (map[i] < map[i + 1])
            {
                return i;
            }
        }

        return -1;
    }

    static int FindInclineEnd(int[] map, int start)
    {
        int i = start;

        while (i < map.Length - 1 && map[i] < map[i + 1])
            i++;

        return i;
    }

    static int FindNextClosestPeek(int[] map, int start)
    {
        if (map.Length - 1 <= start)
        {
            return -1;
        }

        int next = start + 1;

        for (int i = start + 2; i < map.Length; i++)
        {
            if (map[next] < map[i])
            {
                next = i;
            }

            if (map[start] <= map[next])
            {
                break;
            }
        }

        return next;
    }
}