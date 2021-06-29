using System;
using System.Linq;

namespace Demo.Clip04
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

        public bool CanBuild() =>
            !string.IsNullOrWhiteSpace(this.DataSource) &&
            !string.IsNullOrWhiteSpace(this.InitialCatalog) &&
            !string.IsNullOrWhiteSpace(this.UserId) &&
            !(this.Password is null);

        public string Build() =>
            this.CanBuild() ? this.SafeBuild()
            : throw new InvalidOperationException("Cannot build a valid connection string.");

        private string SafeBuild() =>
            $"Data Source={this.Escape(this.DataSource)};" +
            $"Initial Catalog={this.Escape(this.InitialCatalog)};" +
            $"User Id={this.Escape(this.UserId)};Password={this.Escape(this.Password)}";

        private string Escape(string value) =>
            ";' \t".Any(ch => value?.Contains(ch) ?? false) ? $"\"{value?.Replace("\"", "\"\"")}\""
            : value?.Contains("\"") ?? false ? $"'{value}'"
            : value;
    }
}