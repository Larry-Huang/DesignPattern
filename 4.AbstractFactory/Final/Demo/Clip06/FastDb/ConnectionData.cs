using System;
using System.Collections.Generic;
using System.Linq;

namespace Demo.Clip06.FastDb
{
    class ConnectionData
    {
        private IDictionary<string, string> KeyValues { get; }

        public ConnectionData(string connectionString)
        {
            this.KeyValues = connectionString
                .Split(';')
                .Select(pair => (keyValue: pair, separatorPos: pair.IndexOf('=')))
                .ToDictionary(
                    pair => pair.keyValue.Substring(0, pair.separatorPos),
                    pair => pair.keyValue.Substring(pair.separatorPos + 1));

            if (this.UnsupportedKeys.Any())
                throw new ArgumentException("Not all keys are supported.");
        }

        private IEnumerable<string> UnsupportedKeys =>
            this.KeyValues.Keys
                .Except(new[] {this.ServerKey, this.DatabaseKey, this.UserNameKey, this.PasswordKey});

        public string Server =>
            this.KeyValues.TryGetValue(this.ServerKey, out string server) ? server : "localhost";

        public string Database => this.KeyValues[this.DatabaseKey];

        public Credentials Credentials =>
            new UserCredentials(this.UserName, this.Password);

        private string UserName => this.KeyValues[this.UserNameKey];

        private string Password => this.KeyValues[this.PasswordKey];

        private string ServerKey => "Data Source";
        private string DatabaseKey => "Initial Catalog";
        private string UserNameKey => "User Id";
        private string PasswordKey => "Password";
    }
}
