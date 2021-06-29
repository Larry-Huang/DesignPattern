namespace Demo.Clip05.Data
{
    public interface IConnection
    {
        void Connect();
        void Disconnect();
        object Execute(ICommand command, ITransaction transaction);
    }
}
