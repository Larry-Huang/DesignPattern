using Demo.Common;

namespace Demo.Clip07.Modifiers
{
    public class FromSecond : CalculatingModifier
    {
        public FromSecond(IDeduction deduction) : base(deduction)
        {
        }

        protected override (Money first, Money second) ApplyTo(Money a, Money b, Money deduction) =>
            (a, b >= deduction ? b - deduction : b.Currency.Zero);
    }
}
