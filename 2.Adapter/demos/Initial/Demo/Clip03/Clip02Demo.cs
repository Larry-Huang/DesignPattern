using System;
using System.Collections.Generic;
using Demo.Common;

namespace Demo.Clip03
{
    class Clip03Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 3;
        protected override void Implementation()
        {
            KeywordIndex<IWithSimpleKeywords> index = new KeywordIndex<IWithSimpleKeywords>();

            Book item1 = new Book("The Largest Book Ever", "long", "boring");
            Video anotherItem = new Video("The Longest Video Ever");
            VideoKeywords item2 = new VideoKeywords(anotherItem);

            index.Add(item1);
            index.Add(item2);
            Console.WriteLine(index);
            Console.WriteLine();

            string query = "long";
            IEnumerable<IWithSimpleKeywords> results = index.FindApproximate(query);
            
            Console.WriteLine($"Searching for '{query}': {results.ToSequenceString("; ")}");
        }
    }
}
