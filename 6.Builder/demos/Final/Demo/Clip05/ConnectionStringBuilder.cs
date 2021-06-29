using System;
using System.Linq;

namespace Demo.Clip05
{
    class ConnectionStringBuilder
    {
        private string DataSource { get; set; }
        private string InitialCatalog { get; set; }
        private string Security { get; set; }
        private bool IsSecurityValid { get; set; }
        private string ConnectTimeoutSegment { get; set; } = string.Empty;
        private string ProviderSegment { get; set; }

        public ConnectionStringBuilder WithDataSource(string address)
        {
            this.DataSource = address;
            return this;
        }

        public ConnectionStringBuilder WithDataSource(string address, int portNumber)
        {
            this.DataSource = $"{address},{portNumber}";
            return this;
        }

        public ConnectionStringBuilder WithInitialCatalog(string initialCatalog)
        {
            this.InitialCatalog = initialCatalog;
            return this;
        }

        public ConnectionStringBuilder WithCredentials(string userId, string password)
        {
            this.IsSecurityValid = !string.IsNullOrWhiteSpace(userId) && !(password is null);
            this.Security = $"User Id={this.Escape(userId)};Password={this.Escape(password)}";
            return this;
        }

        public ConnectionStringBuilder UseIntegratedSecurity()
        {
            this.IsSecurityValid = true;
            this.Security = "Integrated Security=true";
            return this;
        }

        public ConnectionStringBuilder UseTrustedConnection()
        {
            this.IsSecurityValid = true;
            this.Security = "Trusted_Connection=yes";
            return this;
        }
        
        public ConnectionStringBuilder WithConnectTimeout(int seconds)
        {
            this.ConnectTimeoutSegment = $";Connect Timeout={seconds}";
            return this;
        }

        public ConnectionStringBuilder WithDefaultConnectTimeout()
        {
            this.ConnectTimeoutSegment = string.Empty;
            return this;
        }

        public ConnectionStringBuilder WithProvider(string name)
        {
            this.ProviderSegment ??= $"Provider={this.Escape(name)};";
            return this;
        }

        public ConnectionStringBuilder WithDefaultProvider()
        {
            this.ProviderSegment = null;
            return this;
        }

        public bool CanBuild() =>
            !string.IsNullOrWhiteSpace(this.DataSource) &&
            !string.IsNullOrWhiteSpace(this.InitialCatalog) &&
            this.IsSecurityValid;

        public string Build() =>
            this.CanBuild() ? this.SafeBuild()
            : throw new InvalidOperationException("Cannot build a valid connection string.");

        public Func<string> AsFactory() =>
            this.CanBuild() ? (Func<string>)this.SafeBuild
            : throw new InvalidOperationException("Cannot construct a factory.");
            
        private string SafeBuild() =>
            $"{this.ProviderSegment}Data Source={this.Escape(this.DataSource)};" +
            $"Initial Catalog={this.Escape(this.InitialCatalog)};" +
            $"{this.Security}{this.ConnectTimeoutSegment}";

        private string Escape(string value) =>
            ";' \t".Any(ch => value?.Contains(ch) ?? false) ? $"\"{value?.Replace("\"", "\"\"")}\""
            : value?.Contains("\"") ?? false ? $"'{value}'"
            : value;
    }
}