using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demo.Common;

namespace Demo.Clip01
{
    class Clip01Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 1;
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
