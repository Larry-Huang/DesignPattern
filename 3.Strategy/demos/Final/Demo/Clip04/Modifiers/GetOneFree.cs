using Demo.Common;

namespace Demo.Clip04.Modifiers
{
    public class GetOneFree : IPriceModifier
    {
        public (Money first, Money second) ApplyTo(Money a, Money b) =>
            (a, b.Currency.Zero);
    }
}
