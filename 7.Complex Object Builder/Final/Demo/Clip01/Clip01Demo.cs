using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip01
{
    class Clip01Demo : Common.Demo
    {
        protected override void Implementation()
        {
            Repository repo = new Repository();

            Console.WriteLine();
            repo.Categories.ToList().ForEach(tuple => Console.WriteLine(tuple));

            Console.WriteLine();
            repo.Books.ToList().ForEach(tuple => Console.WriteLine(tuple));

            IEnumerable<Book> books = new BooksBuilder()
                .WithCategories(repo.Categories)
                .WithBooks(repo.Books)
                .Build();

            Console.WriteLine();
            books.ToList().ForEach(Console.WriteLine);
        }
    }
}
