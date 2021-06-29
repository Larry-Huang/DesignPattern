using System.Collections.Generic;
using System.Linq;
using Demo.Clip06.Volumes;

namespace Demo.Clip06
{
    public abstract class Volume
    {
        public abstract string GetLabel(string prefix, string suffix);
        public abstract IEnumerable<string> GetTitles(int whenMoreThan);

        public static Volume Create(
            (string label, string title) first,
            params (string label, string title)[] others) =>
            others.Length == 0 ? (Volume)new SeparateVolume(first.label, first.title)
            : new MultipleVolumes(new[] {first}.Concat(others)
                .Select(tuple => new SeparateVolume(tuple.label, tuple.title)));
    }
}
