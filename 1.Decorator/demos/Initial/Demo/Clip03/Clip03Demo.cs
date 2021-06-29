using Demo.Common;

namespace Demo.Clip03
{
    class Clip03Demo : Common.Demo
    {
        protected override int ClipNumber => 3;
        protected override void Implementation()
        {
            Book product = new Book(
                "Design Patterns", 
                new Size(188 * Length.Millimeter, 239 * Length.Millimeter, 28 * Length.Millimeter));

            BookHandler buyer = new BookHandler();
            buyer.Handle(product);

            Book wrappedProduct = new WrappedBook(product);
            BookHandler dispatcher = new BookHandler();
            dispatcher.Handle(wrappedProduct);
        }
    }
}
