namespace Demo.Clip01.CheapDb
{
    public class Connection
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
    }
}
