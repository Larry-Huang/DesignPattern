using System;
using Demo.Common;

namespace Demo.Clip02
{
    public class TakeTwoOffer
    {
        private Book First { get; }
        private Book Second { get; }

        private Func<Money, Money> Modify { get; }

        public TakeTwoOffer(Func<Money, Money> modify, Book first, Book second)
        {
            this.Modify = modify;
            this.First = first;
            this.Second = second;
        }

        public static TakeTwoOffer GetOneFree(Book first, Book second) =>
            new TakeTwoOffer(price => price.Currency.Zero, first, second);

        public static TakeTwoOffer Deduct(Money amount, Book first, Book second) =>
            new TakeTwoOffer(price => price - amount, first, second);

        public (Book first, Book second) Apply() => 
            this.DeductFromCheaper();

        private (Book first, Book second) DeductFromCheaper()
        {
            var books = this.Sort();
            return (
                books.expensive, 
                books.cheap.WithEffectivePrice(this.Modify(books.cheap.Price)));
        }

        private (Book expensive, Book cheap) Sort() =>
            this.First.Price >= this.Second.Price ? (this.First, this.Second)
            : (this.Second, this.First);
    }
}
