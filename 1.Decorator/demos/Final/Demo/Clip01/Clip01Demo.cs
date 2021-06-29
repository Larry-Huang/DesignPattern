using Demo.Common;

namespace Demo.Clip01
{
    class Clip01Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 1;
        private readonly Length mm = Length.Millimeter;

        protected override void Implementation()
        {
            Book product = new Book("Design Patterns", new Size(188*mm, 239*mm, 28*mm));

            Buyer customer = new Buyer();
            customer.Handle(product);

            Dispatcher employee = new Dispatcher();
            employee.Handle(product);
        }
    }
}
