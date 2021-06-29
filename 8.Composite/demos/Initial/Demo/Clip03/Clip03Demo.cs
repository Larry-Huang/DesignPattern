using System;
using Demo.Clip03.Names;

namespace Demo.Clip03
{
    class Clip03Demo : Common.Demo
    {
        protected override void Implementation()
        {
            try
            {
                Book littlePrince = new Book(
                    "The Little Prince", 
                    new SingleName("Antoine de Saint-Exupéry"));

                Book oosc = new Book(
                    "Object-Oriented Software Construction", 
                    new SingleName("Bertrand Meyer"));

                Book patterns = new Book(
                    "Design Patterns",
                    new ManyNames(new [] { 
                        new SingleName("Erich Gamma"), new SingleName("Richard Helm"),
                        new SingleName("Ralph Johnson"), new SingleName("John Vlissides")}));

                Book nights1001 = new Book(
                    "One Thousand and One Nights",
                    new Anonymous());

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
