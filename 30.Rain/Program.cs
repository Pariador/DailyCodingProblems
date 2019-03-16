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
            new int[] { 3, 0, 0, 2, 0, 5, 0, 3, 0, 0, 4 },
            new int[] { 0, 1, 0, 2, 1, 0, 1, 3, 2, 1, 2, 1 }
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

        int leftMax = map[0];
        int rightMax = map[map.Length - 1];

        int left = 1;
        int right = map.Length - 2;

        while (left <= right)
        {
            if (leftMax < rightMax)
            {
                if (leftMax < map[left])
                    leftMax = map[left];
                else
                    rain += leftMax - map[left];

                left++;
            }
            else
            {
                if (rightMax < map[right])
                    rightMax = map[right];
                else
                    rain += rightMax - map[right];

                right--;
            }
        }

        return rain;
    }
}