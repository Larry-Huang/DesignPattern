using Demo.Clip06.Data;

namespace Demo.Clip06.CheapDb
{
    public class Transaction : ITransaction
    {
        private int TransactionId { get; }
        private Connection Connection { get; }

        public Transaction(Connection connection)
        {
            this.Connection = connection;
            this.TransactionId =
                connection.SendCommand("BEGIN TRANSACTION") is int id ? id : -1;
        }

        public void Commit() =>
            this.Connection.SendCommand("COMMIT TRANSACTION");

        public void Rollback() =>
            this.Connection.SendCommand("ROLLBACK TRANSACTION");

        public override string ToString() =>
            $"Transaction(Id={this.TransactionId})";
    }
}
