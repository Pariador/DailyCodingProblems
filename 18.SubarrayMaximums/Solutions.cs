using System.Collections.Generic;
using System.Linq;

class Solutions
{
    // slowest
    public static int[] Recompute(int[] numbers, int subarrayLength)
    {
        int[] results = new int[numbers.Length - (subarrayLength - 1)];

        for (int r = 0; r < results.Length; r++)
        {
            int max = numbers[r];
            for (int s = 1; s < subarrayLength; s++)
            {
                if (max < numbers[r + s])
                {
                    max = numbers[r + s];
                }
            }

            results[r] = max;
        }

        return results;
    }

    // better
    public static int[] InsertionSort(int[] numbers, int subarrayLength)
    {
        int[] results = new int[numbers.Length - (subarrayLength - 1)];

        var subarray = new SortedDictionary<int, int>();

        int i;
        for (i = 0; i < subarrayLength; i++)
        {
            if (!subarray.ContainsKey(numbers[i]))
            {
                subarray[numbers[i]] = 0;
            }

            subarray[numbers[i]]++;
        }

        results[0] = subarray.Keys.Last();

        for (; i < numbers.Length; i++)
        {
            if (!subarray.ContainsKey(numbers[i]))
            {
                subarray[numbers[i]] = 0;
            }

            subarray[numbers[i]]++;

            int removed = numbers[i - subarrayLength];
            subarray[removed]--;
            if (subarray[removed] == 0)
            {
                subarray.Remove(removed);
            }

            results[i - (subarrayLength - 1)] = subarray.Keys.Last();
        }

        return results;
    }

    // best
    public static int[] ImprovedInsertionSort(int[] numbers, int subarrayLength)
    {
        int[] results = new int[numbers.Length - (subarrayLength - 1)];

        var subarray = new LinkedList<int>();

        int i;
        for (i = 0; i < subarrayLength; i++)
        {
            PushInsert(subarray, numbers, i);
        }

        results[0] = numbers[subarray.First()];

        for (; i < numbers.Length; i++)
        {
            PushInsert(subarray, numbers, i);

            // Remove out of range maximums.
            while (subarray.Any() && subarray.First.Value <= i - subarrayLength)
            {
                subarray.RemoveFirst();
            }

            subarray.AddLast(i);

            results[i - (subarrayLength - 1)] = numbers[subarray.First()];
        }

        return results;
    }

    private static LinkedList<int> PushInsert(LinkedList<int> subarray, int[] numbers, int i)
    {
        while (subarray.Any() && numbers[subarray.Last.Value] < numbers[i])
        {
            subarray.RemoveLast();
        }

        subarray.AddLast(i);

        return subarray;
    }
}