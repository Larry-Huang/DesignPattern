using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using Demo.Common;

namespace Demo.Clip07
{
    class Clip07Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 7;

        protected override void Implementation()
        {
            HashSet<Book> books = new HashSet<Book>(new BookTitleComparer());

            SortedList<string, Book> sorted = new SortedList<string, Book>(
                StringComparer.Create(CultureInfo.GetCultureInfo("de-DE"), true));
            Book product = new Book("Der Kleine Prinz", new Money(8.11M, new Currency("EUR")));
            sorted.Add(product.Title, product);

            IEnumerable<Book> sequence = new[] {product};
            IEnumerable<Book> results = sequence
                .Where(book => book.Price < new Money(20, new Currency("EUR")))
                .OrderBy(book => book.Title, StringComparer.Create(CultureInfo.GetCultureInfo("de-DE"), true));
        }
    }
}
