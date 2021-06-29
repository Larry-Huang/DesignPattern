using Demo.Common;

namespace Demo.Clip04
{
    abstract class BookDecorator : IBook
    {
        public virtual string Title => this.Target.Title;
        private IBook Target { get; }

        protected BookDecorator(IBook other)
        {
            this.Target = other;
        }

        public virtual Size GetDimensions(Size propaganda) =>
            this.Target.GetDimensions(propaganda);
    }
}