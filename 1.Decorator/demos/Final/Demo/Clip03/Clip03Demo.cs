using Demo.Common;

namespace Demo.Clip03
{
    class Clip03Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 3;
        private readonly Length mm = Length.Millimeter;

        protected override void Implementation()
        {
            Book bareBook = new Book("Design Patterns", new Size(188*mm, 239*mm, 28*mm));
            Book product = new TwoPack(bareBook);

            BookHandler buyer = new BookHandler();
            buyer.Handle(product);

            Book wrappedProduct = new WrappedBook(product);
            BookHandler dispatcher = new BookHandler();
            dispatcher.Handle(wrappedProduct);
        }
    }
}
