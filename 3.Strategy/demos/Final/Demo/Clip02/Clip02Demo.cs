using System;
using Demo.Common;

namespace Demo.Clip02
{
    class Clip02Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 2;

        protected override void Implementation()
        {
            Book product = new Book(
                "Design Patterns: Elements of Reusable Object-oriented Software",
                new Money(35, new Currency("USD")));
            Book another = new Book(
                "The Little Prince",
                new Money(9, new Currency("USD")));

            TakeTwoOffer offer = TakeTwoOffer.Deduct(product.Price.Currency.Of(7), another, product);

            var cart = offer.Apply();
            
            Console.WriteLine();
            Console.WriteLine(cart.first);

            Console.WriteLine();
            Console.WriteLine(cart.second);
        }
    }
}
