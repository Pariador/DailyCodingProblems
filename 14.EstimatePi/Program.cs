using System;

static class Program
{
    private static readonly Random Random = new Random();

    static void Main(string[] args)
    {
        int estimations = 10;
        int pointCount = 10000000;

        Console.WriteLine($"Estimating pi {estimations} times, with {pointCount} points each...");
        for (int i = 0; i < 10; i++)
        {
            double pi = EstimatePi(10000000);

            Console.WriteLine($"{(i + 1).ToString("d2")}: pi = {pi.ToString("f3")}");
        }
    }

    static double Distance(double[] first, double[] second)
    {
        return Math.Sqrt(Math.Pow(first[0] - second[0], 2) + Math.Pow(first[1] - second[1], 2));
    }

    // Using Monte Carlo method: https://en.wikipedia.org/wiki/Monte_Carlo_method
    static double EstimatePi(int pointCount)
    {
        const double Radius = 1;

        double area = 0;
        double[] center = { 0, 0 };

        for (int i = 0; i < pointCount; i++)
        {
            double[] point = new double[] { Random.NextDouble(), Random.NextDouble() };

            if (Distance(center, point) < Radius)
            {
                area++;
            }
        }

        double percent = area / pointCount;

        // Area is calculated for 1/4 of a circle.
        double pi = 4 * percent;

        return pi;
    }
}