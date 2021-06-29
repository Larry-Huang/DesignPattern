using Demo.Common;

namespace Demo.Clip05.Modifiers
{
    public class AbsoluteWithSpillover : IPriceModifier
    {
        private Money Amount { get; }

        public AbsoluteWithSpillover(Money amount)
        {
            this.Amount = amount;
        }

        public (Money first, Money second) ApplyTo(Money a, Money b)
        {
            Money bDeduction = b >= this.Amount ? this.Amount : b;
            Money spill = this.Amount - bDeduction;
            Money aDeduction = a >= spill ? spill : a;
            return (a - aDeduction, b - bDeduction);
        }
    }
}