using System.Linq;
using Demo.Clip05.Names;

namespace Demo.Clip05
{
    public abstract class Name
    {
        public abstract string Printable { get; }

        public static Name Anonymous =>
            new Anonymous();

        public static Name Create(string first, params string[] others) =>
            others.Length == 0 ? (Name)new SingleName(first)
            : new ManyNames(new[] {first}.Concat(others).Select(name => new SingleName(name)));
    }
}