using System;

namespace Demo.Clip03
{
    class Clip03Demo : Common.Demo
    {
        protected override void Implementation()
        {
            try
            {
                string connString = new ConnectionStringBuilder()
                    .WithDataSource("localhost")
                    .WithInitialCatalog("DemoDB")
                    .WithCredentials("my", "name")
                    .Build();

                Console.WriteLine(connString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
