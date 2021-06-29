using System;
using System.Linq;

namespace Demo.Clip02
{
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
            Console.WriteLine(connString);
        }
    }
}
