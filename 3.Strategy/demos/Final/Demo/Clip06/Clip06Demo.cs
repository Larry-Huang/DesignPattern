using System;
using Demo.Clip06.Modifiers;
using Demo.Common;

namespace Demo.Clip06
{
    class Clip06Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 6;

        protected override void Implementation()
        {
            this.Apply(new TakeTwoOffer(new GetSecondFree()));

            this.Apply(new TakeTwoOffer(
                new FromSecondWithSpillover(new Absolute(new Money(12, new Currency("USD"))))));

            this.Apply(new TakeTwoOffer(
                new FromSecondWithSpillover(new RelativeToTotal(.1M))));

            this.Apply(new TakeTwoOffer(
                new FromSecondWithSpillover(new RelativeToTotal(.25M))));

            this.Apply(new TakeTwoOffer(
                new Proportional(new Absolute(new Money(12, new Currency("USD"))))));
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
