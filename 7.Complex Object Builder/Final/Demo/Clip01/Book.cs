using System;

namespace Demo.Clip01
{
    public class Book
    {
        public int Id { get; }
        public string Title { get; }
        public Category Category { get; }

        public Book(int id, string title, Category category)
        {
            this.Id = id;
            this.Title = title;
            this.Category = category ?? throw new ArgumentNullException(nameof(category));
        }

        public override string ToString() =>
            $"{this.Category}: {this.Title}";
    }
}
