using System;
using System.Linq;

namespace Demo.Clip05
{
    class Clip05Demo : Common.Demo
    {
        private void Display(string title, params string[] authors)
        {
            try
            {
                Name name = 
                    authors.Length == 0 ? Name.Anonymous
                        : Name.Create(authors[0], authors.Skip(1).ToArray());

                Book book = new Book(title, name);
                Console.WriteLine(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        protected override void Implementation()
        {
            this.Display("The Little Prince", "Antoine de Saint-Exupéry");
            this.Display("Object-Oriented Software Construction", "Bertrand Meyer");
            this.Display("Design Patterns", 
                "Erich Gamma", "Richard Helm", "Ralph Johnson", "John Vlissides");
            this.Display("One Thousand and One Nights");
        }
    }
}
