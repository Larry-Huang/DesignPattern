using System;
using System.Collections.Generic;
using Demo.Common;

namespace Demo.Clip04
{
    class Clip04Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 4;
        protected override void Implementation()
        {
            KeywordIndex<IWithSimpleKeywords> index = new KeywordIndex<IWithSimpleKeywords>();

            Book item1 = new Book("The Largest Book Ever", "long", "boring");

            Video anotherItem = new Video("Making the Long, Long Ad", "making-the-long-long-ad");
            KeywordsRepository repo = new KeywordsRepository();
            IEnumerable<string> keywords = repo.FindFor(anotherItem.Handle);

            VideoKeywords item2 = new VideoKeywords(anotherItem, keywords);

            Video yetAnotherItem = new Video("Братья Карамазовы", "karamazov-brothers");
            VideoKeywords item3 = new VideoKeywords(yetAnotherItem, repo.FindFor(yetAnotherItem.Handle));

            index.Add(item1);
            index.Add(item2);
            index.Add(item3);
            Console.WriteLine(index);
            Console.WriteLine();

            string query = "long";
            IEnumerable<IWithSimpleKeywords> results = index.FindApproximate(query);

            Console.WriteLine($"Searching for '{query}': {results.ToSequenceString("; ")}");
        }
    }
}
