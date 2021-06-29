using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text.RegularExpressions;

namespace Demo.Clip04
{
    public class WordSet : IEnumerable<string>
    {
        private IImmutableSet<string> Content { get; }
        private IEnumerable<string> SkipWords { get; }

        public WordSet(IEnumerable<string> skipWords)
        {
            this.Content = ImmutableHashSet.Create<string>(StringComparer.OrdinalIgnoreCase);
            this.SkipWords = skipWords.ToList();
        }

        private WordSet(IEnumerable<string> skipWords, IImmutableSet<string> content)
        {
            this.SkipWords = skipWords;
            this.Content = content;
        }

        public WordSet AddText(string text) =>
            new WordSet(
                this.SkipWords,
                this.Content.Union(this.BreakIntoWords(text).Where(this.ShouldRetain)));

        private bool ShouldRetain(string word) =>
            this.SkipWords.All(skip => !string.Equals(word, skip, StringComparison.OrdinalIgnoreCase));

        private IEnumerable<string> BreakIntoWords(string content) =>
            Regex.Matches(content, @"[\p{L}0-9-]+")
                .Select(match => match.Value);

        public IEnumerator<string> GetEnumerator() =>
            this.Content.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() =>
            this.GetEnumerator();
    }
}
