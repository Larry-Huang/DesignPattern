using System;
using System.Collections.Generic;
using Demo.Common;

namespace Demo.Clip04
{
    class Clip04Demo : Common.Demo
    {
        protected override int ClipNumber { get; } = 4;

        private IEnumerable<string> SkipWordsEnglish { get; } = new[]
        {
            "no", "nor", "not", "off", "out", "so", "up", "a",
            "and", "as", "at", "but", "by", "en", "for", "if",
            "in", "of", "on", "or", "the", "to", "v", "vs",
            "via", "an", "the"
        };

        private IEnumerable<string> SkipWordsRussian { get; } = new[]
        {
            "я", "мы", "ты", "вы", "он", "она", "оно", "они"
        };

        private Func<WordSet> GetWordSetFactory(IEnumerable<string> skipWord) =>
            () => new WordSet(skipWord);

        protected override void Implementation()
        {
            KeywordIndex<IWithSimpleKeywords> index = new KeywordIndex<IWithSimpleKeywords>();

            Book item1 = new Book("The Largest Book Ever", "long", "boring");

            Video anotherItem = new Video("Making the Long, Long Ad", "making-the-long-long-ad");
            KeywordsRepository repo = new KeywordsRepository();

            IWithSimpleKeywords item2 = new PresetKeywords(
                new VideoKeywords(anotherItem, this.GetWordSetFactory(SkipWordsEnglish)),
                repo.FindFor(anotherItem.Handle));

            Video yetAnotherItem = new Video("Братья Карамазовы", "karamazov-brothers");
            IWithSimpleKeywords item3 = new PresetKeywords(
                new VideoKeywords(yetAnotherItem, this.GetWordSetFactory(SkipWordsRussian)),
                repo.FindFor(yetAnotherItem.Handle));

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
