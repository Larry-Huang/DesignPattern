using System;
using Demo.Common;

namespace Demo.Clip02
{
    class Buyer
    {
        public void Handle(Book product)
        {
            Size bookSize = product.Dimensions;
            Console.WriteLine(
                $"Buying book \"{product.Title}\" of size {bookSize}");
        }
    }
}
