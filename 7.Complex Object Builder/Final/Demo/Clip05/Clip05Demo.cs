using System;

namespace Demo.Clip05
{
    class Clip05Demo : Common.Demo
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
                    .WithInitialCatalog("DemoDB")
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
