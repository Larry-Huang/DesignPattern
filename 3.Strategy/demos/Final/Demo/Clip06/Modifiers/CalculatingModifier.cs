using Demo.Common;

namespace Demo.Clip06.Modifiers
{
    public abstract class CalculatingModifier : IPriceModifier
    {
        private IDeduction Deduction { get; }

        protected CalculatingModifier(IDeduction deduction)
        {
            this.Deduction = deduction;
        }

        public (Money first, Money second) ApplyTo(Money a, Money b) =>
            this.ApplyTo(a, b, this.Deduction.From(a, b));

        protected abstract (Money first, Money second) ApplyTo(
            Money a, Money b, Money deduction);
    }
}
