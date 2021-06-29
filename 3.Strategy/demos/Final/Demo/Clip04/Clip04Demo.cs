using System;
using Demo.Clip04.Modifiers;
using Demo.Common;

namespace Demo.Clip04
{
    class Clip04Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 4;

        protected override void Implementation()
        {
            this.Apply(new TakeTwoOffer(new GetOneFree()));
            this.Apply(new TakeTwoOffer(new FixedDeduction(new Money(7, new Currency("USD")))));
            this.Apply(new TakeTwoOffer(new FixedDeductionWithSpillover(new Money(12, new Currency("USD")))));
        }

        private void Apply(TakeTwoOffer offer)
        {
            Book first = new Book(
                "Design Patterns: Elements of Reusable Object-oriented Software",
                new Money(35, new Currency("USD")));
            Book second = new Book(
                "The Little Prince",
                new Money(9, new Currency("USD")));

            var cart = offer.ApplyTo(first, second);

            Console.WriteLine();
            Console.WriteLine(cart.first);
            Console.WriteLine(cart.second);
        }
    }
}
