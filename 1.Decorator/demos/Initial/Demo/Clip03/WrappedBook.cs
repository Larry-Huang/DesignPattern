using Demo.Common;

namespace Demo.Clip03
{
    class WrappedBook : Book
    {
        public WrappedBook(Book other) 
            : base(other)
        {
        }

        public override Size GetDimensions(Size propaganda) =>
            base.GetDimensions(propaganda)
                .Add(new Size(7 * Length.Millimeter, 7 * Length.Millimeter, 7 * Length.Millimeter));
    }
}