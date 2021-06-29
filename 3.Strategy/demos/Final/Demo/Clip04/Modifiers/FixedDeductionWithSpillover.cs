using Demo.Common;

namespace Demo.Clip04.Modifiers
{
    public class FixedDeductionWithSpillover : IPriceModifier
    {
        private Money Amount { get; }

        public FixedDeductionWithSpillover(Money amount)
        {
            this.Amount = amount;
        }

        public (Money first, Money second) ApplyTo(Money a, Money b)
        {
            Money deduct = b >= this.Amount ? this.Amount : b;
            Money spill = this.Amount - deduct;
            Money deductSpill = a >= spill ? spill : a;
            return (a - deductSpill, b - deduct);
        }
    }
}
