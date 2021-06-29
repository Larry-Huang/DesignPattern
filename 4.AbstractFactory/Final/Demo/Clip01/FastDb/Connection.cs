namespace Demo.Clip01.FastDb
{
    public class Connection
    {
        private string Server { get; }
        private string Database { get; }
        private Credentials Credentials { get; }

        public Connection(string server, string database, Credentials credentials)
        {
            Server = server;
            Database = database;
            Credentials = credentials;
        }
    }
}
