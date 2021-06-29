namespace Demo.Clip01
{
    public class TakeTwoOffer
    {
        private Book First { get; }
        private Book Second { get; }

        public TakeTwoOffer(Book first, Book second)
        {
            this.First = first;
            this.Second = second;
        }

        public (Book first, Book second) Apply() => this.DeductFromCheaper(7);

        protected virtual (Book first, Book second) DeductFromCheaper(decimal amount)
        {
            var books = this.Sort();
            return (
                books.expensive,
                books.cheap.WithEffectivePrice(books.cheap.Price.SubtractAmount(amount)));
        }

        private (Book expensive, Book cheap) Sort() =>
            this.First.Price >= this.Second.Price ? (this.First, this.Second)
            : (this.Second, this.First);
    }
}