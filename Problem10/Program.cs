namespace Problem10
{
    using System;
    using System.Threading;

    static class Program
    {
        private static Random Random = new Random();

        static void Main(string[] args)
        {
            Console.WriteLine("Printing hello world after 3 seconds:");
            CallAfter(() => Console.WriteLine("Hello World!"), 3000);

            Console.WriteLine("\nScheduling jobs.");
            Scheduler scheduler = new Scheduler();
            for (int i = 0; i < 100; i++)
            {
                int miliseconds = Random.Next(1000, 10001);

                int jobNumber = i + 1;
                Job job = new Job(() => Console.WriteLine("Executed job: " + jobNumber), miliseconds);

                scheduler.Schdule(job);
            }

            Console.WriteLine("\nRunning jobs:");
            scheduler.Run();
        }

        static void CallAfter(Action action, int miliseconds)
        {
            Thread.Sleep(miliseconds);

            action();
        }
    }
}