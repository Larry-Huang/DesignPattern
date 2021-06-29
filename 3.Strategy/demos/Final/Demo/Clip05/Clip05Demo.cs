using System;
using Demo.Clip05.Modifiers;
using Demo.Common;

namespace Demo.Clip05
{
    class Clip05Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 5;

        protected override void Implementation()
        {
            this.Apply(new TakeTwoOffer(new GetSecondFree()));
            this.Apply(new TakeTwoOffer(new AbsoluteWithSpillover(new Money(12, new Currency("USD")))));
            this.Apply(new TakeTwoOffer(new RelativeToTotalWithSpillover(.1M)));
            this.Apply(new TakeTwoOffer(new RelativeToTotalWithSpillover(.25M)));
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
