using System;

namespace Demo.Clip01
{
    public class Book
    {
        public string Title { get; }
        public string Author { get; }

        public Book(string title, string author)
        {
            this.Title = title;
            this.Author = author;
        }

        public override string ToString() =>
            $"{this.Author}, {this.Title}";
    }
}
