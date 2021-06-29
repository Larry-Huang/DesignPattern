using Demo.Common;

namespace Demo.Clip07.Modifiers
{
    public class Absolute : IDeduction
    {
        private Money Amount { get; }

        public Absolute(Money amount)
        {
            this.Amount = amount;
        }

        public Money From(Money a, Money b) => 
            this.Amount;
    }
}
