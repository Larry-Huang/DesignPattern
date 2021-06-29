using System;
using System.Linq;

namespace Demo.Clip04
{
    class ConnectionStringBuilder
    {
        private string DataSource { get; }
        private string InitialCatalog { get; }
        private string Security { get; }
        private string ConnectTimeoutSegment { get; set; } = string.Empty;
        private string ProviderSegment { get; set; }

        public static ConnectionStringBuilder WithCredentials(
            string user, string password, string initialCatalog, string dataSource) =>
            new ConnectionStringBuilder(initialCatalog, dataSource, string.Empty,
                                        Credentials(user, password));

        public static ConnectionStringBuilder WithCredentials(
            string user, string password, string initialCatalog, string dataSource, int port) =>
            new ConnectionStringBuilder(initialCatalog, dataSource, $",{port}",
                                        Credentials(user, password));

        private static string Credentials(string user, string password) =>
            !string.IsNullOrWhiteSpace(user) && !(password is null)
                ? $"User Id={Escape(user)};Password={Escape(password)}"
                : throw new ArgumentException();

        public static ConnectionStringBuilder UsingIntegratedSecurity(
            string initialCatalog, string dataSource) =>
            new ConnectionStringBuilder(initialCatalog, dataSource, string.Empty,
                                        "Integrated Security=true");
        
        public static ConnectionStringBuilder UsingIntegratedSecurity(
            string initialCatalog, string dataSource, int port) =>
            new ConnectionStringBuilder(initialCatalog, dataSource, $",{port}",
                                        "Integrated Security=true");

        public static ConnectionStringBuilder UsingTrustedConnection(
            string initialCatalog, string dataSource) =>
            new ConnectionStringBuilder(initialCatalog, dataSource, string.Empty,
                                        "Trusted Connection=yes");

        public static ConnectionStringBuilder UsingTrustedConnection(
            string initialCatalog, string dataSource, int port) =>
            new ConnectionStringBuilder(initialCatalog, dataSource, $",{port}",
                                        "Trusted_Connection=yes");

        private ConnectionStringBuilder(
            string initialCatalog, string dataSource, string formattedPort, string security)
        {
            this.InitialCatalog = !string.IsNullOrWhiteSpace(initialCatalog)
                ? initialCatalog
                : throw new ArgumentException(nameof(initialCatalog));

            this.DataSource = !string.IsNullOrWhiteSpace(dataSource)
                ? $"{dataSource}{formattedPort}"
                : throw new ArgumentException(nameof(dataSource));

            this.Security = security;
        }

        public ConnectionStringBuilder WithConnectTimeout(int seconds)
        {
            this.ConnectTimeoutSegment = $";Connect Timeout={seconds}";
            return this;
        }

        public ConnectionStringBuilder WithProvider(string name)
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