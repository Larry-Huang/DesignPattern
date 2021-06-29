using System;

namespace Demo.Clip04
{
    class Clip04Demo : Common.Demo
    {
        protected override void Implementation()
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine(ConnectionStringBuilder
                    .UsingIntegratedSecurity("DemoDB", "localhost")
                    .WithConnectTimeout(10)
                    .Build());

                Console.WriteLine();
                Console.WriteLine(ConnectionStringBuilder
                    .WithCredentials("my", "name", "DemoDB", "bank.my.org/SQL", 1435)
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
