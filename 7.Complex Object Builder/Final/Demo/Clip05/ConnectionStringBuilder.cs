using System;
using System.Linq;

namespace Demo.Clip05
{
    class ConnectionStringBuilder : 
        IExpectsInitialCatalog, IExpectsAuthentication, IOptionalsBuilder
    {
        private string DataSource { get; set; }
        private string InitialCatalog { get; set; }
        private string Security { get; set; }
        private string ConnectTimeoutSegment { get; set; } = string.Empty;
        private string ProviderSegment { get; set; }

        private ConnectionStringBuilder() { }

        public static IExpectsInitialCatalog WithDataSource(string dataSource) =>
            new ConnectionStringBuilder() { DataSource = ValidDataSource(dataSource) };

        public static IExpectsInitialCatalog WithDataSource(string dataSource, int port) =>
            new ConnectionStringBuilder()
            {
                DataSource = $"{ValidDataSource(dataSource)},{port}"
            };

        private static string ValidDataSource(string dataSource) =>
            !string.IsNullOrWhiteSpace(dataSource) ? dataSource
            : throw new ArgumentException(nameof(dataSource));

        public IExpectsAuthentication WithInitialCatalog(string initialCatalog)
        {
            this.InitialCatalog = ValidInitialCatalog(initialCatalog);
            return this;
        }

        private static string ValidInitialCatalog(string initialCatalog) =>
            !string.IsNullOrWhiteSpace(initialCatalog) ? initialCatalog
            : throw new ArgumentException(nameof(initialCatalog));

        public IOptionalsBuilder WithCredentials(string userId, string password)
        {
            this.Security = Credentials(userId, password);
            return this;
        }

        private static string Credentials(string user, string password) =>
            !string.IsNullOrWhiteSpace(user) && !(password is null)
                ? $"User Id={Escape(user)};Password={Escape(password)}"
                : throw new ArgumentException();

        public IOptionalsBuilder UsingIntegratedSecurity()
        {
            this.Security = "Integrated Security=true";
            return this;
        }

        public IOptionalsBuilder UsingTrustedConnection()
        {
            this.Security = "Trusted_Connection=yes";
            return this;
        }

        public IOptionalsBuilder WithConnectTimeout(int seconds)
        {
            this.ConnectTimeoutSegment = $";Connect Timeout={seconds}";
            return this;
        }

        public IOptionalsBuilder WithProvider(string name)
        {
            this.ProviderSegment ??= $"Provider={Escape(name)};";
            return this;
        }
        
        public string Build() =>
            $"{this.ProviderSegment}Data Source={Escape(this.DataSource)};" +
            $"Initial Catalog={Escape(this.InitialCatalog)};" +
            $"{this.Security}{this.ConnectTimeoutSegment}";

        private static string Escape(string value) =>
            ";' \t".ToCharArray().Any(ch => value?.Contains(ch) ?? false) ? $"\"{value?.Replace("\"", "\"\"")}\""
            : value?.Contains("\"") ?? false ? $"'{value}'"
            : value;
    }
}