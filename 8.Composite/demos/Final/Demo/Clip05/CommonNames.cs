using System.Linq;
using Demo.Clip05.Names;

namespace Demo.Clip05
{
    public class CommonNames : INameFactory
    {
        public Name Anonymous => new Anonymous();

        public Name Create(string first, params string[] others) =>
            others.Length == 0 ? (Name)new SingleName(first)
            : new ManyNames(
                new[] {first}.Concat(others).Select(name => new SingleName(name)));
    }
}