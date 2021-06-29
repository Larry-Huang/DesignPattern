using System.Collections.Generic;

namespace Demo.Clip01
{
    public class Book : IWithSimpleKeywords
    {
        public string Title { get; }
        public IEnumerable<string> Keywords { get; }

        public Book(string title, params string[] keywords)
        {
            this.Title = title;
            this.Keywords = keywords;
        }

        public override string ToString() =>
            this.Title;
    }
}
