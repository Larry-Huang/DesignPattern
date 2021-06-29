using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip02
{
    public class VideoKeywords : IWithSimpleKeywords
    {
        private Video Target { get; }

        public VideoKeywords(Video target)
        {
            this.Target = target;
        }

        public override string ToString() =>
            this.Target?.ToString() ?? string.Empty;

        public IEnumerable<string> Keywords =>
            this.Target.Title
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(keyword => keyword.Length > 3);
    }
}
