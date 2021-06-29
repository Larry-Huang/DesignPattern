using System;
using Demo.Common;

namespace Demo.Clip03
{
    class BookHandler
    {
        public void Handle(Book product)
        {
            Size slimCdCase = new Size(
                142 * Length.Millimeter,
                125 * Length.Millimeter,
                5 * Length.Millimeter);

            Size size = product.GetDimensions(slimCdCase);
            Console.WriteLine($"Dealing with {product.GetType().Name} of size {size}");
        }
    }
}
