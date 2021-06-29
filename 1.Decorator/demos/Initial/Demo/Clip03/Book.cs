using Demo.Common;

namespace Demo.Clip03
{
    class Book
    {
        public string Title { get; }
        private Size Dimensions { get; }

        public Book(string title, Size dimensions)
        {
            this.Title = title;
            this.Dimensions = dimensions;
        }

        protected Book(Book other)
            : this(other.Title, other.Dimensions)
        {
        }

        public virtual Size GetDimensions(Size propaganda) =>
            this.Dimensions.AddToTop(propaganda);

        public override string ToString() =>
            $"{this.Title} - {this.Dimensions}";
    }
}
