using System;
using System.Collections.Generic;
using System.Linq;

static class Program
{
    static void Main()
    {
        int[] numbers = { 2, 1, 5, 7, 2, 0, 5 };
        Console.WriteLine("Numbers:");
        Console.WriteLine(string.Join(" ", numbers));

        double[] medians = RunningMedians(numbers);

        Console.WriteLine("\nMedians:");
        foreach (var median in medians)
            Console.WriteLine(median);
    }

    static double[] RunningMedians(int[] numbers)
    {
        if (numbers == null || numbers.Length == 0)
            throw new ArgumentException("Numbers can't be null or empty!");

        double[] medians = new double[numbers.Length];
        medians[0] = numbers[0];

        if (numbers.Length == 1)
            return medians;

        medians[1] = (numbers[0] + numbers[1]) / 2.0;

        var leftSorted = new SortedDictionary<int, int>();
        leftSorted[Math.Min(numbers[0], numbers[1])] = 1;
        int leftCount = 1;

        var rightSorted = new SortedDictionary<int, int>();
        rightSorted[Math.Max(numbers[0], numbers[1])] = 1;
        int rightCount = 1;

        for (int i = 2; i < numbers.Length; i++)
        {
            if (numbers[i] <= leftSorted.Keys.Last())
            {
                Add(leftSorted, numbers[i]);
                leftCount++;
            }
            else
            {
                Add(rightSorted, numbers[i]);
                rightCount++;
            }

            int left = leftSorted.Keys.Last();
            int right = rightSorted.Keys.First();
            if (leftCount + 1 < rightCount)
            {
                Remove(rightSorted, right);
                rightCount--;

                Add(leftSorted, right);
                leftCount++;
            }
            else if (leftCount > rightCount + 1)
            {
                Remove(leftSorted, left);
                leftCount--;

                Add(rightSorted, left);
                rightCount++;
            }

            left = leftSorted.Keys.Last();
            right = rightSorted.Keys.First();
            if (leftCount > rightCount)
                medians[i] = left;
            else if (leftCount < rightCount)
                medians[i] = right;
            else
                medians[i] = (right + left) / 2.0;
        }

        return medians;
    }

    static void Add(IDictionary<int, int> numbers, int number)
    {
        if (numbers.ContainsKey(number))
            numbers[number]++;
        else
            numbers[number] = 1;
    }

    static bool Remove(IDictionary<int, int> numbers, int number)
    {
        if (!numbers.ContainsKey(number))
            return false;

        numbers[number]--;

        if (numbers[number] <= 0)
            numbers.Remove(number);

        return true;
    }
}