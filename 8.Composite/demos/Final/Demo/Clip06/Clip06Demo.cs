using System;
using System.Linq;

namespace Demo.Clip06
{
    class Clip06Demo : Common.Demo
    {
        private void Display(string title, Name author, Volume volumes)
        {
            try
            {
                Book book = new Book(title, author, volumes);
                Console.WriteLine();
                Console.WriteLine(book);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }

        private void Display(string title, Name author) =>
            this.Display(title, author, Volume.Create(("1", title)));

        private void Display(INameFactory nameFactory)
        {
            this.Display("The Lord of the Rings", 
                nameFactory.Create("John Tolkien"),
                Volume.Create(
                    ("I", "The Fellowship of the Ring"),
                    ("II", "The Two Towers"),
                    ("III", "The Return of the King")));

            this.Display("Object-Oriented Software Construction", 
                nameFactory.Create("Bertrand Meyer"));

            this.Display("Design Patterns", nameFactory.Create(
                "Erich Gamma", "Richard Helm", "Ralph Johnson", "John Vlissides"));

            this.Display("The Art of Computer Programming", 
                nameFactory.Create("Donald Knuth"),
                Volume.Create(
                    ("1", "Fundamental Algorithms"),
                    ("2", "Seminumerical Algorithms"),
                    ("3", "Sorting and Searching"),
                    ("4A", "Combinatorial Algorithms")));
        }

        protected override void Implementation()
        {
            this.Display(new CommonNames());
        }
    }
}
