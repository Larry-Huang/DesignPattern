using System;

namespace Demo.Common
{
    abstract class Demo
    {
        protected abstract int ClipNumber { get; }
        protected abstract void Implementation();

        public void Run()
        {
            Console.WriteLine($"Clip {this.ClipNumber:00} demo");
            this.Implementation();
            Console.WriteLine(new string('-', 20));
            Console.WriteLine();
        }
    }
}
