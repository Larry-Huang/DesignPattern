using System.Collections.Generic;
using System.Linq;

namespace Demo.Common
{
    static class EnumerableExtensions
    {
        public static string Join(this IEnumerable<string> sequence, string separator) =>
            string.Join(separator, sequence.ToArray());

        public static string ToSequenceString(this IEnumerable<object> sequence, string separator) =>
            string.Join(separator, sequence.Select(item => item.ToString()));
    }
}
