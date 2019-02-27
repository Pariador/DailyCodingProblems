namespace Problem10
{
    using System;

    class Job : IComparable<Job>
    {
        public Job(Action action, int miliseconds)
        {
            this.Action = action;
            this.Miliseconds = miliseconds;
        }

        public Action Action { get; }

        public int Miliseconds { get; }

        public int CompareTo(Job other)
        {
            return this.Miliseconds.CompareTo(other.Miliseconds);
        }
    }
}