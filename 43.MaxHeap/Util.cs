using System.Collections.Generic;

static class Util
{
    public static void Swap<T>(this IList<T> items, int first, int second)
    {
        var hold = items[first];
        items[first] = items[second];
        items[second] = hold;
    }       
}