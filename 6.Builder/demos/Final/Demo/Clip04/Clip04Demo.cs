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

                Console.WriteLine(new ConnectionStringBuilder()
                    .WithDataSource("localhost", 1435)
                    .WithInitialCatalog("DemoDB")
                    .UseIntegratedSecurity()
                    .Build());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}