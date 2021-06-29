using Demo.Clip05.Data;

namespace Demo.Clip05.CheapDb
{
    public class Connection : IConnection
    {
        private string Database { get; }
        private string UserName { get; }
        private string Password { get; }

        public Connection(string database, string userName, string password)
        {
            this.Database = database;
            this.UserName = userName;
            this.Password = password;
        }

        public void Connect() { }

        public void Disconnect() { }

        public object Execute(ICommand command, ITransaction transaction) =>
            this.Execute((Command) command, (Transaction) transaction);

        public object Execute(Command command, Transaction transaction) =>
            this.SendCommand(command.Text, transaction);

        public object SendCommand(string text) => 
            new object();

        public object SendCommand(string text, Transaction transaction) => 
            new object();
    }
}
