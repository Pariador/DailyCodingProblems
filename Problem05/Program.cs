namespace Problem5
{
    using System;

    static class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 2)
            {
                args = new string[] { "3", "4" };
            }

            string car = Car(Cons(args[0], args[1]));
            string cdr = Cdr(Cons(args[0], args[1]));

            Console.WriteLine($"Car: {car}");
            Console.WriteLine($"Cdr: {cdr}");
        }

        static T Car<T>(Func<Func<T, T, T>, T> pair)
        {
            return pair((a, b) => a);
        }

        static T Cdr<T>(Func<Func<T, T, T>, T> pair)
        {
            return pair((a, b) => b);
        }

        static Func<Func<T, T, T>, T> Cons<T>(T a, T b)
        {
            Func<Func<T, T, T>, T> pair = (f) =>
            {
                return f(a, b);
            };

            return pair;
        }
    }
}