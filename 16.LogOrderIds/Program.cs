using System;
using System.IO;
using System.Linq;

static class Program
{
    const string LogFile = "log.txt";

    const int LogSize = 100;

    static readonly Random Random = new Random();

    static void Main(string[] args)
    {
        int getCount = 15;
        if (args.Length > 0)
        {
            getCount = int.Parse(args[0]);
        }

        int[] ids = GenerateIds();

        Console.WriteLine("Logging ids...");
        LogOrderId(ids);

        Console.WriteLine($"Getting {getCount} ids at random...");
        for (int i = 0; i < getCount; i++)
        {
            int index = Random.Next(LogSize);

            int id = GetOrderId(index);

            Console.WriteLine($"Id {index} = {id}");
        }
    }

    static void LogOrderId(params int[] ids)
    {
        string[] logs = File.ReadAllLines(LogFile);

        logs = logs.Concat(ids.Select(id => $"Order id: {id}"))
            .ToArray();

        var writer = new StreamWriter(LogFile);
        int start = logs.Length <= LogSize ? 0 : logs.Length - LogSize;
        for (int i = start; i < logs.Length; i++)
        {
            writer.WriteLine(logs[i]);
        }

        writer.Dispose();
    }

    static int GetOrderId(int index)
    {
        var reader = new StreamReader(LogFile);

        string log = null;
        for (int i = 0; i <= index; i++)
        {
            log = reader.ReadLine();
        }

        int id = int.Parse(log.Split(' ')[2]);

        return id;
    }

    static int[] GenerateIds()
    {
        int[] ids = new int[LogSize];

        for (int i = 0; i < ids.Length; i++)
        {
            ids[i] = Random.Next(1, 10001);
        }

        return ids;
    }
}