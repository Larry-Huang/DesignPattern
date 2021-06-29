using Demo.Common;

namespace Demo.Clip06
{
    public interface IPriceModifier
    {
        (Money first, Money second) ApplyTo(Money a, Money b);
    }
}
