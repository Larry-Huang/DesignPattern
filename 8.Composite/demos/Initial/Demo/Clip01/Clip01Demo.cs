using System;

namespace Demo.Clip01
{
    class Clip01Demo : Common.Demo
    {
        protected override void Implementation()
        {
            try
            {
                Book littlePrince = new Book(
                    "The Little Prince",
                    "Antoine de Saint-Exupéry");

                Book oosc = new Book(
                    "Object-Oriented Software Construction",
                    "Bertrand Meyer");

                Console.WriteLine(littlePrince);
                Console.WriteLine(oosc);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"ERROR: {ex.Message}");
            }
        }
    }
}
