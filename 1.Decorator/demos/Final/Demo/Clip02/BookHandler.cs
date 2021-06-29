using System;
using Demo.Common;

namespace Demo.Clip02
{
    class BookHandler
    {
        public void Handle(Book product)
        {
            Size bookSize = product.Dimensions;
            Console.WriteLine($"Dealing with \"{product.Title}\" of size {bookSize}");
        }
    }
}
