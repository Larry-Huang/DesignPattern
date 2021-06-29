using System;
using System.Linq;

namespace Demo.Clip06
{
    class Clip06Demo : Common.Demo
    {
        private void Display(string title, Name author)
        {
            try
            {
                Book book = new Book(title, author);
                Console.WriteLine();
                Console.WriteLine(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        private void Display(INameFactory nameFactory)
        {
            this.Display("The Lord of the Rings", nameFactory.Create("John Tolkien"));
            this.Display("Object-Oriented Software Construction", nameFactory.Create("Bertrand Meyer"));
            this.Display("Design Patterns", nameFactory.Create(
                "Erich Gamma", "Richard Helm", "Ralph Johnson", "John Vlissides"));
            this.Display("The Art of Computer Programming", nameFactory.Create("Donald Knuth"));
        }

        protected override void Implementation()
        {
            this.Display(new CommonNames());
        }
    }
}
