using Demo.Clip05.Data;
using Demo.Clip05.FastDb.Commands;

namespace Demo.Clip05.FastDb
{
    public class FastDataAccess : IDataAccess
    {
        public IConnection CreateConnection(string connectionString) =>
            this.CreateConnection(new ConnectionData(connectionString));

        private IConnection CreateConnection(ConnectionData data) =>
            new Connection(data.Server, data.Database, data.Credentials);

        public ICommand CreateCommand(string commandText) =>
            commandText.StartsWith("INSERT INTO ") ? new InsertCommand(commandText)
            : commandText.StartsWith("DELETE FROM ") ? new DeleteCommand(commandText)
            : commandText.StartsWith("UPDATE ") ? (ICommand)new UpdateCommand(commandText)
            : new SelectCommand(commandText);

        public ITransaction CreateTransaction(IConnection connection) => 
            throw new System.NotImplementedException();
    }
}
