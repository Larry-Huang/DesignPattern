using Demo.Common;

namespace Demo.Clip02
{
    class Clip02Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 2;
        private readonly Length mm = Length.Millimeter;

        protected override void Implementation()
        {
            Book product = new Book("Design Patterns", new Size(188*mm, 239*mm, 28*mm));

            BookHandler buyer = new BookHandler();
            buyer.Handle(product);

            Book wrappedProduct = new WrappedBook(product);
            BookHandler dispatcher = new BookHandler();
            dispatcher.Handle(wrappedProduct);
        }
    }
}
