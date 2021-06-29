using System;
using System.Collections.Generic;

namespace Demo.Clip07
{
    public class BookTitleComparer : IEqualityComparer<Book>
    {
        private IEqualityComparer<string> TitleComparer { get; } = StringComparer.OrdinalIgnoreCase;

        public bool Equals(Book x, Book y) =>
            this.TitleComparer.Equals(x?.Title, y?.Title);

        public int GetHashCode(Book obj) =>
            this.TitleComparer.GetHashCode(obj?.Title);
    }
}