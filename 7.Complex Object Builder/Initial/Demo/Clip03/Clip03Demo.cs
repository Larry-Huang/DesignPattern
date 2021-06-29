using System;

namespace Demo.Clip03
{
    class Clip03Demo : Common.Demo
    {
        protected override void Implementation()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine(new ConnectionStringBuilder()
                    .WithDataSource("localhost")
                    .WithInitialCatalog("DemoDB")
                    .UseIntegratedSecurity()
                    .WithConnectTimeout(10)
                    .Build());

                Console.WriteLine();
                Console.WriteLine(new ConnectionStringBuilder()
                    .WithDataSource("bank.my.org/SQL", 1435)
                    .WithInitialCatalog("DemoDb")
                    .WithCredentials("my", "name")
                    .WithProvider("System.Data.SqlClient")
                    .Build());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
