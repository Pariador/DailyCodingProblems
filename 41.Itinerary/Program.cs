using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// TODO: Finish this...
static class Program
{
    static void Main()
    {
        var flights = ReadFlights("flights.txt", out string start);
        Console.WriteLine($"Start: {start}");
        Console.WriteLine("Flights:");
        foreach (var flight in flights)
        {
            Console.Write("{0} -> {1}", flight.Key, string.Join(", ", flight.Value));
            Console.WriteLine();
        }
        Console.WriteLine();

        var itenerary = FindItenerary(flights, start);
    }

    static string[] FindItenerary(Dictionary<string, List<string>> flights, string start)
    {
        var queue = new Queue<string>();
        var visited = new HashSet<string>();
        queue.Enqueue(start);
        visited.Add(start);

        while (queue.Any())
        {
            var current = queue.Dequeue();
            Console.WriteLine(current);

            foreach (var destination in flights[current].Where(des => !visited.Contains(des)))
            {
                queue.Enqueue(destination);
                visited.Add(destination);
            }
        }

        return null;
    }

    static Dictionary<string, List<string>> ReadFlights(string file, out string start)
    {
        string[] special = { "'", "[", "]", "(", ")" };

        string text = File.ReadAllText(file);

        foreach (var str in special)
        {
            text = text.Replace(str, "");
        }

        string[] airports = text.Split(',')
            .Select(str => str.Trim())
            .ToArray();

        start = airports[0];

        var flights = new Dictionary<string, List<string>>();
        for (int i = 1; i < airports.Length - 1; i += 2)
        {
            var origin = airports[i];
            var destination = airports[i + 1];

            if (!flights.ContainsKey(origin))
            {
                flights[origin] = new List<string>();
            }

            if (!flights.ContainsKey(destination))
            {
                flights[destination] = new List<string>();
            }


            flights[origin].Add(destination);
        }

        return flights;
    }
}