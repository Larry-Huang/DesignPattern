using System;
using System.Linq;

namespace Demo.Clip05
{
    class Clip05Demo : Common.Demo
    {
        private void Display(string title, INameFactory nameFactory, params string[] authors)
        {
            try
            {
                Name name = 
                    authors.Length == 0 ? nameFactory.Anonymous
                    : nameFactory.Create(authors[0], authors.Skip(1).ToArray());

                Book book = new Book(title, name);
                Console.WriteLine(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        private void Display(INameFactory nameFactory)
        {
            Console.WriteLine();
            this.Display("The Little Prince", nameFactory, "Antoine de Saint-Exupéry");
            this.Display("Object-Oriented Software Construction", nameFactory, "Bertrand Meyer");
            this.Display("Design Patterns", nameFactory,
                "Erich Gamma", "Richard Helm", "Ralph Johnson", "John Vlissides");
            this.Display("One Thousand and One Nights", nameFactory);
        }

        protected override void Implementation()
        {
            this.Display(new CommonNames());
            this.Display(new ScientificNames(3));
        }
    }
}
