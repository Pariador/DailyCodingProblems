using System;
using System.Collections.Generic;

static class Program
{
    const int NoLastAdded = -1;
    const int NotSummable = -2;

    static void Main()
    {
        int[] set = { 12, 1, 61, 5, 9, 2 };
        int sum = 24;

        int[] subset = SubsetSum(set, sum);

        Console.WriteLine($"Sum: {sum}");
        Console.WriteLine($"Subset: {string.Join(" ", subset)}");
    }

    static int[] SubsetSum(int[] set, int sum)
    {
        if (sum == 0)
        {
            return new int[0];
        }

        // Sums marks the possible sums of set, as well as
        // the last element used to make the sum.
        // index: sum, value: last element used
        int[] sums = InitSums(sum);
        sums[0] = NoLastAdded;

        int[] next = InitSums(sum);
        for (int i = 0; i < set.Length; i++)
        {
            bool found = false;

            for (int s = 0; s < sums.Length; s++)
            {
                if (sums[s] == NotSummable)
                {
                    continue;
                }

                if (next[s] == NotSummable)
                {
                    next[s] = sums[s];
                }

                int @new = s + set[i];

                if (@new <= sum && next[@new] == NotSummable)
                {
                    next[@new] = i;

                    if (@new == sum)
                    {
                        found = true;
                        break;
                    }
                }
            }

            var hold = sums;
            sums = next;
            next = hold;

            if (found == true)
            {
                break;
            }
        }
        
        return Reconstruct(set, sum, sums);
    }

    static int[] Reconstruct(int[] set, int sum, int[] sums)
    {
        if (sums[sum] == NotSummable)
        {
            return new int[0];
        }

        var subset = new List<int>();

        for (int i = sum; sums[i] != NoLastAdded; i = i - set[sums[i]])
        {
            subset.Add(set[sums[i]]);
        }

        return subset.ToArray();
    }

    static int[] InitSums(int sum)
    {
        int[] sums = new int[sum + 1];

        for (int i = 0; i < sums.Length; i++)
        {
            sums[i] = NotSummable;
        }

        return sums;
    }
}