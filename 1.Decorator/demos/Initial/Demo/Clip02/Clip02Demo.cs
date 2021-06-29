using Demo.Common;

namespace Demo.Clip02
{
    class Clip02Demo : Common.Demo
    {
        protected override int ClipNumber => 2;

        protected override void Implementation()
        {
            Book product = new Book("Design Patterns", new Size(
                188 * Length.Millimeter,
                239 * Length.Millimeter,
                28 * Length.Millimeter));

            Buyer customer = new Buyer();
            customer.Handle(product);

            Dispatcher employee = new Dispatcher();
            employee.Handle(product);
        }
    }
}
