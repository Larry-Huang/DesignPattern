using System;
using System.Collections.Generic;
using Demo.Common;

namespace Demo.Clip02
{
    class Clip02Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 2;
        protected override void Implementation()
        {
            KeywordIndex<Book> index = new KeywordIndex<Book>();

            Book item = new Book("The Largest Book Ever", "long", "boring");
            Video anotherItem = new Video("The Longest Video Ever");

            index.Add(item);
            Console.WriteLine(index);
            Console.WriteLine();

            string query = "long";
            IEnumerable<Book> results = index.Find(query);

            Console.WriteLine($"Searching for '{query}': {results.ToSequenceString(", ")}");
        }
    }
}
