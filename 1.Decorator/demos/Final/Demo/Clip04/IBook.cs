using Demo.Common;

namespace Demo.Clip04
{
    interface IBook
    {
        string Title { get; }
        Size GetDimensions(Size propaganda);
    }
}
