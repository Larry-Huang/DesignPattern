using Demo.Common;

namespace Demo.Clip05.Modifiers
{
    public class RelativeToLowerWithSpillover : IPriceModifier
    {
        private decimal Factor { get; }

        public RelativeToLowerWithSpillover(decimal factor)
        {
            this.Factor = factor;
        }

        public (Money first, Money second) ApplyTo(Money a, Money b)
        {
            Money deduction = this.Factor * (a < b ? a : b);
            Money bDeduction = b >= deduction ? deduction : b;
            Money spill = deduction - bDeduction;
            Money aDeduction = a >= spill ? spill : a;
            return (a - aDeduction, b - bDeduction);
        }
    }
}