using System;
using Demo.Common;

namespace Demo.Clip01
{
    class Clip01Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 1;

        protected override void Implementation()
        {
            Book product = new Book(
                "Design Patterns: Elements of Reusable Object-oriented Software",
                new Money(35, new Currency("USD")));
            Book another = new Book(
                "The Little Prince",
                new Money(9, new Currency("USD")));

            TakeTwoOffer offer = new TakeTwoOffer(another, product);
            var cart = offer.Apply();

            Console.WriteLine();
            Console.WriteLine(cart.first);

            Console.WriteLine();
            Console.WriteLine(cart.second);
        }
    }
}
