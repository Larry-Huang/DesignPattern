using Demo.Common;

namespace Demo.Clip06.Modifiers
{
    public class FromSecondWithSpillover : CalculatingModifier
    {
        public FromSecondWithSpillover(IDeduction deduction) : base(deduction)
        {
        }

        protected override (Money first, Money second) ApplyTo(Money a, Money b, Money deduction)
        {
            Money bDeduction = b >= deduction ? deduction : b;
            Money spill = deduction - bDeduction;
            Money aDeduction = a >= spill ? spill : a;
            return (a - aDeduction, b - bDeduction);
        }
    }
}