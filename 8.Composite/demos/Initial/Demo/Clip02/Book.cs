using System.Linq;

namespace Demo.Clip02
{
    public class Book
    {
        public string Title { get; }
        public string[] Authors { get; }

        public Book(string title, string firstAuthor, params string[] otherAuthors)
        {
            this.Title = title;
            this.Authors = new[] {firstAuthor}.Concat(otherAuthors).ToArray();
        }

        public override string ToString() =>
            $"{this.AuthorsToString}, {this.Title}";

        private string AuthorsToString =>
            this.Authors.Length == 1 ? this.Authors[0]
            : this.Authors.Length == 2 ? $"{this.Authors[0]}, {this.Authors[1]}"
            : $"{this.Authors[0]} et al.";
    }
}
