using System;
using Demo.Common;

namespace Demo.Clip05.Modifiers
{
    public class RelativeToLower : IPriceModifier
    {
        private decimal Factor { get; }

        public RelativeToLower(decimal factor)
        {
            this.Factor = 0 <= factor && factor <= 1 ? factor : throw new ArgumentException(nameof(factor));
        }

        public (Money first, Money second) ApplyTo(Money a, Money b) =>
            this.ApplyTo(a, b, this.Factor * (a < b ? a : b));

        private (Money first, Money second) ApplyTo(Money a, Money b, Money discount) =>
            (a, b >= discount ? b - discount : b.Currency.Zero);
    }
}
