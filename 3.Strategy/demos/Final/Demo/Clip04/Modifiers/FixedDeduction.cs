using Demo.Common;

namespace Demo.Clip04.Modifiers
{
    public class FixedDeduction : IPriceModifier
    {
        private Money Amount { get; }

        public FixedDeduction(Money amount)
        {
            this.Amount = amount;
        }

        public (Money first, Money second) ApplyTo(Money a, Money b) =>
            b >= this.Amount ? (a, b - this.Amount)
            : (a, b.Currency.Zero);
    }
}
