using System;

namespace Demo.Clip05
{
    class Clip05Demo : Common.Demo
    {
        private void DoStuff(Func<string> connStringFactory)
        {
            string connString = connStringFactory();
            Console.WriteLine($"Doing stuff: {connString}");
        }

        private void DoStuff(Func<string, string, string> connStringFactory)
        {
            string connString = connStringFactory("my", "name");
            Console.WriteLine($" More stuff: {connString}");
        }

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
                    .WithInitialCatalog("DemoDb")
                    .UseIntegratedSecurity()
                    .Build());

                this.DoStuff(new ConnectionStringBuilder()
                    .WithDataSource("localhost")
                    .WithInitialCatalog("DemoDB")
                    .WithCredentials("my", "name")
                    .WithProvider("System.Data.SqlClient")
                    .AsFactory());

                this.DoStuff((userId, password) => new ConnectionStringBuilder()
                    .WithDataSource("localhost")
                    .WithInitialCatalog("DemoDB")
                    .WithCredentials(userId, password)
                    .Build());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
