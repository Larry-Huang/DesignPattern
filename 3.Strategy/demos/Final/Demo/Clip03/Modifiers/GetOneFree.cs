using Demo.Common;

namespace Demo.Clip03.Modifiers
{
    public class GetOneFree : IPriceModifier
    {
        public Money ApplyTo(Money price) =>
            price.Currency.Zero;
    }
}
