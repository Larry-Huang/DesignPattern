using System;
using System.Linq;

namespace Demo.Clip02
{
    class ConnectionStringBuilder
    {
        private string DataSource { get; set; }
        private string InitialCatalog { get; set; }
        private string UserId { get; set; }
        private string Password { get; set; }

        public ConnectionStringBuilder WithDataSource(string address)
        {
            this.DataSource = address;
            return this;
        }

        public ConnectionStringBuilder WithInitialCatalog(string initialCatalog)
        {
            this.InitialCatalog = initialCatalog;
            return this;
        }

        public ConnectionStringBuilder WithCredentials(string userId, string password)
        {
            this.UserId = userId;
            this.Password = password;
            return this;
        }

        public string Build() =>
            $"Data Source={this.Escape(this.DataSource)};" +
            $"Initial Catalog={this.Escape(this.InitialCatalog)};" +
            $"User Id={this.Escape(this.UserId)};Password={this.Escape(this.Password)}";

        private string Escape(string value) =>
            ";' \t".Any(value.Contains) ? $"\"{value.Replace("\"", "\"\"")}\""
            : value.Contains("\"") ? $"'{value}'"
            : value;
    }

    class Clip02Demo : Common.Demo
    {
        private string Escape(string value) =>
            ";' \t".Any(value.Contains) ? $"\"{value.Replace("\"", "\"\"")}\""
            : value.Contains("\"") ? $"'{value}'"
            : value;

        private string CreateConnString(
            string dataSource, int portNumber, string initialCatalog,
            string userId, string password, bool integratedSecurity) =>
            $"Data Source={this.Escape(portNumber < 0 ? dataSource : $"{dataSource},{portNumber}")};" +
            $"Initial Catalog={this.Escape(initialCatalog)};" +
            (integratedSecurity ? 
                "Integrated Security=true" : 
                $"User Id={this.Escape(userId)};Password={this.Escape(password)}");

        protected override void Implementation()
        {
            string connString = CreateConnString("localhost", -1, "DemoDB", "my", "name", false);

            string connString1 = new ConnectionStringBuilder()
                .WithDataSource("localhost")
                .WithInitialCatalog("DemoDB")
                .WithCredentials("my", "name")
                .Build();

            Console.WriteLine(connString);
            Console.WriteLine(connString1);
        }
    }
}
