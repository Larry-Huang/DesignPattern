using Demo.Common;

namespace Demo.Clip04
{
    class TwoPack : BookDecorator
    {
        public TwoPack(IBook other) : base(other) { }

        public override Size GetDimensions(Size propaganda) =>
            base.GetDimensions(Size.Zero)
                .ScaleHeight(2)
                .AddToTop(propaganda);
    }
}