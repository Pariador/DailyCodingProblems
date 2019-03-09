using System;
using System.Linq;

static class Program
{
    static void Main(string[] args)
    {
        int[] times = { 1, 40, 30, 75, 35, 55, 80, 100, 60, 75, 65, 70, 68, 69, 20, 30, 25, 28, 90, 95 };
        if (args.Length > 0)
        {
            times = args.Select(int.Parse)
                .ToArray();
        }

        int minRooms = MinRooms(times);

        Console.WriteLine($"Minumum number of rooms: {minRooms}");
    }

    static int MinRooms(int[] times)
    {
        var events = ToSortedEvents(times);

        int max = 0;
        int rooms = 0;

        foreach (var @event in events)
        {
            if (@event.Type == EventType.Start)
            {
                rooms++;
            }
            else
            {
                rooms--;
            }

            if (max < rooms)
            {
                max = rooms;
            }
        }

        return max;
    }

    static Event[] ToSortedEvents(int[] times)
    {
        Event[] events = new Event[times.Length];

        for (int i = 0; i < times.Length; i += 2)
        {
            events[i] = new Event(times[i], EventType.Start);
            events[i + 1] = new Event(times[i + 1], EventType.Stop);
        }

        return events.OrderBy(@event => @event.Time)
            .ToArray();
    }
}