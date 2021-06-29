namespace Demo.Clip06.Data
{
    public interface IDataAccess
    {
        IConnection CreateConnection(string connectionString);
        ICommand CreateCommand(string commandText);
        ITransaction CreateTransaction(IConnection connection);
    }
}
