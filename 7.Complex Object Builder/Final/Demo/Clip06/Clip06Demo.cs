using System;

namespace Demo.Clip06
{
    class Clip06Demo : Common.Demo
    {
        protected override void Implementation()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine(ConnectionStringBuilder
                    .WithDataSource("localhost")
                    .WithInitialCatalog("DemoDB")
                    .UsingIntegratedSecurity()
                    .WithConnectTimeout(10)
                    .Build());

                Console.WriteLine();
                Console.WriteLine(ConnectionStringBuilder
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
