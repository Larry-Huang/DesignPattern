using System.Linq;
using Demo.Clip06.Names;

namespace Demo.Clip06
{
    public class ScientificNames : INameFactory
    {
        private int MaxNames { get; }

        public ScientificNames(int maxNames)
        {
            this.MaxNames = maxNames;
        }

        public Name Anonymous => new Anonymous();

        public Name Create(string first, params string[] others) =>
            1 + others.Length > this.MaxNames ? new FirstEtAl(new ScientificName(first))
            : others.Length == 0 ? (Name)new ScientificName(first)
            : new ManyNames(new[] {first}.Concat(others).Select(name => new ScientificName(name)));
    }
}