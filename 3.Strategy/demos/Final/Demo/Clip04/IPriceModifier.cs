using Demo.Common;

namespace Demo.Clip04
{
    public interface IPriceModifier
    {
        (Money first, Money second) ApplyTo(Money a, Money b);
    }
}
