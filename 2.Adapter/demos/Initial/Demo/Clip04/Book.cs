using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip04
{
    public class Book : IWithSimpleKeywords, IEquatable<IWithSimpleKeywords>
    {
        public string Title { get; }
        public IEnumerable<string> Keywords => this.SortedKeywords;

        private IEnumerable<string> SortedKeywords { get; }

        public Book(string title, params string[] keywords)
        {
            this.Title = title;
            this.SortedKeywords = keywords
                .Select(keyword => keyword.ToLowerInvariant())
                .OrderBy(x => x)
                .ToList();
        }

        public override string ToString() =>
            this.Title;

        public bool Equals(IWithSimpleKeywords other) =>
            other is Book book && this.Equals(book);

        public override bool Equals(object obj) =>
            obj is Book book && this.Equals(book);

        private bool Equals(Book other) =>
            other.GetType() == typeof(Book) &&
            other.Title.Equals(this.Title) &&
            other.SortedKeywords.SequenceEqual(this.SortedKeywords);

        public override int GetHashCode()
        {
            unchecked
            {
                return this.Keywords.Aggregate(
                    this.Title.GetHashCode(),
                    (hashCode, keyword) => hashCode * 17 + keyword.GetHashCode());
            }
        }
    }
}
