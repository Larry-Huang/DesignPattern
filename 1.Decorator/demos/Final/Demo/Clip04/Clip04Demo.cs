using Demo.Common;

namespace Demo.Clip04
{
    class Clip04Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 4;
        private readonly Length mm = Length.Millimeter;

        protected override void Implementation()
        {
            IBook bareBook = new PrintedBook("Design Patterns", new Size(188*mm, 239*mm, 28*mm));
            IBook product = new TwoPack(bareBook);

            BookHandler buyer = new BookHandler();
            buyer.Handle(product);

            IBook wrappedProduct = new WrappedBook(product);
            BookHandler dispatcher = new BookHandler();
            dispatcher.Handle(wrappedProduct);
        }
    }
}
