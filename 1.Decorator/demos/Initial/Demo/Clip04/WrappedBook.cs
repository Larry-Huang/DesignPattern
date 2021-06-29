using Demo.Common;

namespace Demo.Clip04
{
    class WrappedBook : Book
    {
        public WrappedBook(Book other) 
            : base(other)
        {
        }

        public override Size GetDimensions(Size propaganda) =>
            base.GetDimensions(propaganda)
                .Add(new Size(
                    7 * Length.Millimeter,
                    7 * Length.Millimeter,
                    7 * Length.Millimeter));
    }
}