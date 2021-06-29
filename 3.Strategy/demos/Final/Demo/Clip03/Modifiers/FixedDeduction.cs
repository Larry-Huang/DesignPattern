using Demo.Common;

namespace Demo.Clip03.Modifiers
{
    public class FixedDeduction : IPriceModifier
    {
        private Money Amount { get; }
        
        public FixedDeduction(Money amount)
        {
            this.Amount = amount;
        }

        public Money ApplyTo(Money price) =>
            price - this.Amount;
    }
}
