using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip04
{
    public class PresetKeywords : IWithSimpleKeywords, IEquatable<IWithSimpleKeywords>
    {
        private IWithSimpleKeywords Target { get; }
        private IEnumerable<string> SubstituteKeywords { get; }

        public IEnumerable<string> Keywords =>
            this.SubstituteKeywords.Any() ? this.SubstituteKeywords
            : this.Target.Keywords;

        public PresetKeywords(IWithSimpleKeywords target, IEnumerable<string> keywords)
        {
            this.Target = target;
            this.SubstituteKeywords = keywords.ToList();
        }

        public bool Equals(IWithSimpleKeywords other) =>
            other is PresetKeywords preset && this.Equals(preset);

        private bool Equals(PresetKeywords other) =>
            this.Target.Equals(other.Target);

        public override string ToString() =>
            this.Target.ToString();
    }
}
