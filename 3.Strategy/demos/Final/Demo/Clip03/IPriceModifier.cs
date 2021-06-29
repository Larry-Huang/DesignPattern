using Demo.Common;

namespace Demo.Clip03
{
    public interface IPriceModifier
    {
        Money ApplyTo(Money price);
    }
}
