using System;
using System.Linq;

namespace Demo.Clip06
{
    class ConnectionStringBuilder : 
        IExpectsInitialCatalog, IExpectsAuthentication, IOptionalsBuilder
    {
        private string DataSource { get; }
        private string InitialCatalog { get; }
        private string Security { get; }
        private string ConnectTimeoutSegment { get; }
        private string ProviderSegment { get; }

        private ConnectionStringBuilder(
            string dataSource, string initialCatalog, string security,
            string connectionTimeoutSegment, string providerSegment)
        {
            this.DataSource = dataSource;
            this.InitialCatalog = initialCatalog;
            this.Security = security;
            this.ConnectTimeoutSegment = connectionTimeoutSegment;
            this.ProviderSegment = providerSegment;
        }

        public static IExpectsInitialCatalog WithDataSource(string dataSource) =>
            new ConnectionStringBuilder(ValidDataSource(dataSource), 
                                        null, null, string.Empty, null);

        public static IExpectsInitialCatalog WithDataSource(string dataSource, int port) =>
            new ConnectionStringBuilder($"{ValidDataSource(dataSource)},{port}",
                                        null, null, string.Empty, null);
        
        private static string ValidDataSource(string dataSource) =>
            !string.IsNullOrWhiteSpace(dataSource) ? dataSource 
            : throw new ArgumentException(nameof(dataSource));

        public IExpectsAuthentication WithInitialCatalog(string initialCatalog) =>
            new ConnectionStringBuilder(
                this.DataSource, ValidInitialCatalog(initialCatalog),
                this.Security, this.ConnectTimeoutSegment, this.ProviderSegment);

        private static string ValidInitialCatalog(string initialCatalog) =>
            !string.IsNullOrWhiteSpace(initialCatalog) ? initialCatalog
            : throw new ArgumentException(nameof(initialCatalog));

        public IOptionalsBuilder WithCredentials(string userId, string password) =>
            new ConnectionStringBuilder(
                this.DataSource, this.InitialCatalog, Credentials(userId, password),
                this.ConnectTimeoutSegment, this.ProviderSegment);

        private static string Credentials(string user, string password) =>
            !string.IsNullOrWhiteSpace(user) && !(password is null)
                ? $"User Id={Escape(user)};Password={Escape(password)}"
                : throw new ArgumentException();

        public IOptionalsBuilder UsingIntegratedSecurity() =>
            new ConnectionStringBuilder(
                this.DataSource, this.InitialCatalog, "Integrated Security=true",
                this.ConnectTimeoutSegment, this.ProviderSegment);

        public IOptionalsBuilder UsingTrustedConnection() =>
            new ConnectionStringBuilder(
                this.DataSource, this.InitialCatalog, "Trusted_Connection=yes",
                this.ConnectTimeoutSegment, this.ProviderSegment);
        
        public IOptionalsBuilder WithConnectTimeout(int seconds) =>
            new ConnectionStringBuilder(
                this.DataSource, this.InitialCatalog, this.Security,
                $";Connect Timeout={seconds}", this.ProviderSegment);

        public IOptionalsBuilder WithProvider(string name) =>
            new ConnectionStringBuilder(
                this.DataSource, this.InitialCatalog, this.Security, this.ConnectTimeoutSegment, 
                this.ProviderSegment ?? $"Provider={Escape(ValidProvider(name))};");

        private string ValidProvider(string name) =>
            !string.IsNullOrEmpty(name) ? name
            : throw new ArgumentException(nameof(name));

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