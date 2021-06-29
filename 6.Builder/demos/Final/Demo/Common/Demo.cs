using System;
using System.Text.RegularExpressions;

namespace Demo.Common
{
    abstract class Demo
    {
        protected virtual int ClipNumber => NumberFrom(this.GetType().Name);
        protected abstract void Implementation();

        public void Run()
        {
            Console.WriteLine($"Clip {this.ClipNumber:00} demo");
            this.Implementation();
            Console.WriteLine(new string('-', 20));
        }

        private static int NumberFrom(string typeName) =>
            Regex.Match(typeName, @"\d+") is Match match &&
            match.Success
                ? int.Parse(match.Value)
                : throw new InvalidOperationException($"Cannot infer clip number from type name {typeName}");
    }
}
