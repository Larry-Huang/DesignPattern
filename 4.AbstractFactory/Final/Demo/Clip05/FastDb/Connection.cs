using System.ComponentModel;
using Demo.Clip05.Data;
using Demo.Clip05.FastDb.Commands;

namespace Demo.Clip05.FastDb
{
    public class Connection : IConnection
    {
        private string Server { get; }
        private string Database { get; }
        private Credentials Credentials { get; }

        public Connection(string server, string database, Credentials credentials)
        {
            this.Server = server;
            this.Database = database;
            this.Credentials = credentials;
        }

        public void Connect() { }

        public void Disconnect() { }

        public object Execute(ICommand command, ITransaction transaction) =>
            this.Execute(command, (Transaction) transaction);

        private object Execute(ICommand command, Transaction transaction) =>
            command is SelectCommand select ? select.Execute(transaction)
            : command is InsertCommand insert ? insert.Execute(transaction).key
            : command is UpdateCommand update ? update.Execute(transaction)
            : command is DeleteCommand delete ? delete.Execute(transaction)
            : throw new InvalidEnumArgumentException("Unsupported command type.");
    }
}
