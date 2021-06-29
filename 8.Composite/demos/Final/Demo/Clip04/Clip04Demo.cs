using System;

namespace Demo.Clip04
{
    class Clip04Demo : Common.Demo
    {
        protected override void Implementation()
        {
            try
            {
                Book littlePrince = new Book(
                    "The Little Prince", Name.Create("Antoine de Saint-Exupéry"));

                Book oosc = new Book(
                    "Object-Oriented Software Construction", Name.Create("Bertrand Meyer"));

                Book patterns = new Book(
                    "Design Patterns",
                    Name.Create("Erich Gamma", "Richard Helm",
                                "Ralph Johnson", "John Vlissides"));

                Book nights1001 = new Book(
                    "One Thousand and One Nights", Name.Anonymous);

                Console.WriteLine(littlePrince);
                Console.WriteLine(oosc);
                Console.WriteLine(patterns);
                Console.WriteLine(nights1001);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }
}
