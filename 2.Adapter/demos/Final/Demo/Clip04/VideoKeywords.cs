using System;
using System.Collections.Generic;

namespace Demo.Clip04
{
    public class VideoKeywords : IWithSimpleKeywords, IEquatable<IWithSimpleKeywords>
    {
        private Video Target { get; }
        private Func<WordSet> CreateWordSet { get; }
        
        public VideoKeywords(Video target, Func<WordSet> createWordSet)
        {
            this.Target = target;
            this.CreateWordSet = createWordSet;
        }
        
        public override string ToString() =>
            this.Target.Title;

        public IEnumerable<string> Keywords =>
            this.CreateWordSet().AddText(this.Target.Title);

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