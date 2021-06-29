using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip07
{
    class Clip07Demo : Common.Demo
    {
        protected override void Implementation()
        {
            Repository repo = new Repository();

            IEnumerable<Book> books = new BooksBuilder()
                .WithCategories(repo.Categories)
                .WithBooks(repo.Books)
                .Build();

            Console.WriteLine();
            books.ToList().ForEach(Console.WriteLine);
        }
    }
}
