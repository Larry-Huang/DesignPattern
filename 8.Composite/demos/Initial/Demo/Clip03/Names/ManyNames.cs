using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip03.Names
{
    class ManyNames : Name
    {
        private List<Name> Names { get; }

        public ManyNames(IEnumerable<Name> names)
        {
            this.Names = names.ToList();
        }

        public override string Printable =>
            string.Join(", ", this.Names.Select(name => name.Printable).ToArray());
    }
}