using System;
using Demo.Common;

namespace Demo.Clip02
{
    public class Book
    {
        public string Title { get; }
        public virtual Money Price { get; }
        public Money EffectivePrice { get; }

        public Book(string title, Money price) 
            : this(title, price, price)
        {
        }

        private Book(string title, Money price, Money effectivePrice)
        {
            if (price.Currency != effectivePrice.Currency)
                throw new ArgumentException();

            this.Title = title;
            this.Price = price;
            this.EffectivePrice = effectivePrice;
        }

        public virtual Book WithEffectivePrice(Money price) =>
            new Book(this.Title, this.Price, price);

        public override string ToString() =>
            $"{this.Title}{Environment.NewLine}{this.PriceToString()}";

        private string PriceToString() =>
            this.EffectivePrice == this.Price ? $"{this.EffectivePrice}"
            : $"{this.EffectivePrice} (Was {this.Price})";
    }
}