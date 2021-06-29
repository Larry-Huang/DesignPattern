using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Demo.Clip04
{
    public class VideoKeywords : IWithSimpleKeywords, IEquatable<IWithSimpleKeywords>
    {
        private Video Target { get; }

        private IEnumerable<string> SkipWords { get; } = new[]
        {
            "no", "nor", "not", "off", "out", "so", "up", "a",
            "and", "as", "at", "but", "by", "en", "for", "if",
            "in", "of", "on", "or", "the", "to", "v", "vs",
            "via", "an", "the"
        };

        private IEnumerable<string> ExternalKeywords { get; }
        
        public VideoKeywords(Video target, IEnumerable<string> externalKeywords)
        {
            this.Target = target;
            this.ExternalKeywords = externalKeywords.ToList();
        }
        
        public override string ToString() =>
            this.Target.Title;

        public IEnumerable<string> Keywords =>
            this.ExternalKeywords.Any() ? this.ExternalKeywords
            : this.GenerateKeywords();

        private IEnumerable<string> GenerateKeywords() =>
            this.BreakIntoWords(this.Target.Title)
                .Distinct()
                .Where(keyword => !this.SkipWords.Contains(keyword));

        private IEnumerable<string> BreakIntoWords(string content) =>
            Regex.Matches(content, @"[\p{L}0-9-]+")
                .Select(match => match.Value);

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