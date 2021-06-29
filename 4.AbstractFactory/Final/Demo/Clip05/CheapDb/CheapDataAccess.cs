using System;
using System.Text.RegularExpressions;
using Demo.Clip05.Data;

namespace Demo.Clip05.CheapDb
{
    public class CheapDataAccess : IDataAccess
    {
        public IConnection CreateConnection(string connectionString) =>
            this.IsLocalhost(connectionString)
                ? new Connection(
                    this.Database(connectionString),
                    this.UserName(connectionString),
                    this.Password(connectionString))
                : throw new ArgumentException("Unsupported remote server.");

        public ICommand CreateCommand(string commandText) => 
            new Command(commandText);

        public ITransaction CreateTransaction(IConnection connection) => 
            new Transaction((Connection)connection);

        private bool IsLocalhost(string connectionString) =>
            this.ValueOf(connectionString, "Data Source", "localhost") == "localhost";

        private string Database(string connectionString) => 
            this.ValueOf(connectionString, "Initial Catalog");

        private string UserName(string connectionString) =>
            this.ValueOf(connectionString, "User Id");

        private string Password(string connectionString) =>
            this.ValueOf(connectionString, "Password");

        private string ValueOf(string connectionString, string key) =>
            this.ValueOf(connectionString, key, string.Empty);

        private string ValueOf(string connectionString, string key, string substitute) =>
            Regex.Match(connectionString, $"{key}=(?<value>[^;]+);") is Match pair && pair.Success
                ? pair.Groups["value"].Value
                : substitute;
    }
}
