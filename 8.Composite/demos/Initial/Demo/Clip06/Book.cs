namespace Demo.Clip06
{
    public class Book
    {
        public string Title { get; }
        public Name Author { get; }

        public Book(string title, Name author)
        {
            this.Title = title;
            this.Author = author;
        }

        public override string ToString() =>
            $"{this.Author.Printable}, {this.Title}";
    }
}
