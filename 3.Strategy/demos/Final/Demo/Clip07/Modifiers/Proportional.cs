using Demo.Common;

namespace Demo.Clip07.Modifiers
{
    public class Proportional : CalculatingModifier
    {
        public Proportional(IDeduction deduction) : base(deduction)
        {
        }

        protected override (Money first, Money second) ApplyTo(Money a, Money b, Money deduction)
        {
            decimal factor = b / (a + b);
            Money bDeductionFull = factor * deduction;
            Money bDeduction = b >= bDeductionFull ? bDeductionFull : b;
            Money spill = deduction - bDeduction;
            Money aDeduction = a >= spill ? spill : a;
            return (a - aDeduction, b - bDeduction);
        }
    }
}
