using System;

namespace Demo.Clip04
{
    class Clip04Demo : Common.Demo
    {
        protected override void Implementation()
        {
            try
            {
                Console.WriteLine(new ConnectionStringBuilder()
                    .WithDataSource("localhost")
                    .WithInitialCatalog("DemoDB")
                    .WithCredentials("my", "name")
                    .Build());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}