using System;
using System.Collections.Generic;
using System.Linq;
using Demo.Common;

namespace Demo.Clip01
{
    public class KeywordIndex
    {
        private IDictionary<string, IList<Book>> Index { get; } =
            new Dictionary<string, IList<Book>>();

        public void Add(Book item)
        {
            foreach (string keyword in item.Keywords)
            {
                this.Add(keyword.ToLowerInvariant(), item);
            }
        }

        private void Add(string keyword, Book item) => 
            this.GetListFor(keyword).Add(item);

        private IList<Book> GetListFor(string keyword) =>
            this.Index.TryGetValue(keyword, out IList<Book> list) ? list
            : this.CreateListFor(keyword);

        private IList<Book> CreateListFor(string keyword) 
        {
            IList<Book> list = new List<Book>();
            this.Index[keyword] = list;
            return list;
        }

        public IEnumerable<Book> Find(string keyword) =>
            this.Index.TryGetValue(keyword.ToLowerInvariant(), out IList<Book> books) ? books
            : Enumerable.Empty<Book>();

        public override string ToString() =>
            this.Index
                .SelectMany(keyValue => keyValue.Value.Select(item => (keyword: keyValue.Key, item: item)))
                .Select(tuple => $"{tuple.keyword} -> {tuple.item}")
                .Join(Environment.NewLine);
    }
}
