namespace Demo.Clip01.Data
{
    public interface IDataAccess
    {
        IConnection CreateConnection();
        ICommand CreateCommand();
        ITransaction CreateTransaction(IConnection connection);
    }
}
