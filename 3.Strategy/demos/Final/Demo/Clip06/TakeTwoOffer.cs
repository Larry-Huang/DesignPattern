namespace Demo.Clip06
{
    public class TakeTwoOffer
    {
        private IPriceModifier Modifier { get; }

        public TakeTwoOffer(IPriceModifier modifier)
        {
            this.Modifier = modifier;
        }

        public (Book first, Book second) ApplyTo(Book first, Book second) => 
            this.DeductFromCheaper(first, second);

        private (Book first, Book second) DeductFromCheaper(Book first, Book second)
        {
            var books = this.Sort(first, second);
            var prices = this.Modifier.ApplyTo(books.expensive.Price, books.cheap.Price);
            return (
                books.expensive.WithEffectivePrice(prices.first),
                books.cheap.WithEffectivePrice(prices.second));
        }

        private (Book expensive, Book cheap) Sort(Book first, Book second) =>
            first.Price >= second.Price ? (first, second)
            : (second, first);
    }
}
