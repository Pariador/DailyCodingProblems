namespace Problem10
{
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;

    class Scheduler
    {
        private readonly SortedSet<Job> jobs;

        public Scheduler()
        {
            this.jobs = new SortedSet<Job>();
        }

        public void Schdule(Job job)
        {
            this.jobs.Add(job);
        }

        public void Run()
        {
            Job[] jobs = this.jobs.ToArray();
            this.jobs.Clear();

            Stopwatch watch = Stopwatch.StartNew();

            int i = 0;
            int count = jobs.Length;
            while (count != 0)
            {
                long elapsed = watch.ElapsedMilliseconds;

                for (; i < jobs.Length && jobs[i].Miliseconds <= elapsed; i++)
                {
                    jobs[i].Action();
                    jobs[i] = null;
                    count--;
                }
            }
        }
    }
}