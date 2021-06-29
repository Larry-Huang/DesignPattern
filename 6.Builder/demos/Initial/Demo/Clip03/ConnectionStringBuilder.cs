using System.Linq;

namespace Demo.Clip03
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
            ";' \t".Any(ch => value?.Contains(ch) ?? false) ? $"\"{value?.Replace("\"", "\"\"")}\""
            : value?.Contains("\"") ?? false ? $"'{value}'"
            : value;
    }
}