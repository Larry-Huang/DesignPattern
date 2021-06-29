using Demo.Clip05.Data;

namespace Demo.Clip05.CheapDb
{
    public class Transaction : ITransaction
    {
        private int TransactionId { get; }
        private Connection Connection { get; }

        public Transaction(Connection connection)
        {
            this.Connection = connection;
            this.TransactionId = (int)connection.SendCommand("BEGIN TRANSACTION");
        }

        public void Commit() =>
            this.Connection.SendCommand("COMMIT TRANSACTION");

        public void Rollback() =>
            this.Connection.SendCommand("ROLLBACK TRANSACTION");

        public override string ToString() =>
            $"Transaction(Id={this.TransactionId})";
    }
}
