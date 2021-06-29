using Demo.Common;

namespace Demo.Clip05.Modifiers
{
    public class Absolute : IPriceModifier
    {
        private Money Amount { get; }

        public Absolute(Money amount)
        {
            this.Amount = amount;
        }

        public (Money first, Money second) ApplyTo(Money a, Money b) => 
            (a, b >= this.Amount ? b - this.Amount : b.Currency.Zero);
    }
}
