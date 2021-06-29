using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip03
{
    public class VideoKeywords : IWithSimpleKeywords, IEquatable<IWithSimpleKeywords>
    {
        private Video Target { get; }
        
        public VideoKeywords(Video target)
        {
            this.Target = target;
        }
        
        public override string ToString() =>
            this.Target.Title;

        public IEnumerable<string> Keywords =>
            this.Target.Title
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Where(keyword => keyword.Length > 3);

        public override bool Equals(object obj) =>
            obj is VideoKeywords keywords && this.Equals(keywords);

        public bool Equals(IWithSimpleKeywords other) =>
            other is VideoKeywords keywords && this.Equals(keywords);

        private bool Equals(VideoKeywords other) =>
            this.Target.Equals(other.Target);

        public override int GetHashCode() =>
            this.Target.GetHashCode();
    }
}