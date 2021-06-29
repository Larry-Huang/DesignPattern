using System;

namespace Demo.Clip03
{
    class Clip03Demo : Common.Demo
    {
        private ConnectionStringBuilder FillCredentials(ConnectionStringBuilder partialBuilder) =>
            partialBuilder.WithCredentials("my", "name");

        protected override void Implementation()
        {
            try
            {
                ConnectionStringBuilder builder = new ConnectionStringBuilder()
                    .WithDataSource("localhost")
                    .WithInitialCatalog("DemoDB");

                builder = this.FillCredentials(builder);

                if (builder.CanBuild())
                    Console.WriteLine("Safe to build a connection string...");

                string connString = builder.Build();

                Console.WriteLine(connString);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
