using Demo.Common;

namespace Demo.Clip03
{
    class TwoPack : Book
    {
        public TwoPack(Book other) : base(other)
        {
        }

        public override Size GetDimensions(Size propaganda) =>
            base.GetDimensions(Size.Zero)
                .ScaleHeight(2)
                .AddToTop(propaganda);
    }
}
