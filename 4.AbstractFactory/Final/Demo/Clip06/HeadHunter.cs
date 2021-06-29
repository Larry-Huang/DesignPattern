using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Demo.Clip06.Data;

namespace Demo.Clip06
{
    class HeadHunter
    {
        private string ConnectionString { get; }
        private IDataAccess DatabaseGateway { get; }

        public HeadHunter(string connectionString, IDataAccess databaseGateway)
        {
            this.ConnectionString = connectionString;
            this.DatabaseGateway = databaseGateway;
        }

        public void AddEmployee(string name)
        {
            IConnection conn = this.DatabaseGateway.CreateConnection(this.ConnectionString);
            conn.Connect();

            ITransaction trans = this.DatabaseGateway.CreateTransaction(conn);

            ICommand cmd1 = this.DatabaseGateway.CreateCommand(
                $"INSERT INTO Workers(Name) VALUES ('{name}')");
            var insert = conn.Execute(cmd1, trans);
            Console.WriteLine($"INSERT result: {insert}");

            ICommand cmd2 = this.DatabaseGateway.CreateCommand(
                "SELECT Name FROM Workers");
            var select = conn.Execute(cmd2, trans);
            string selectReport = select is IEnumerable<string> namesSequence
                ? string.Join(", ", namesSequence.ToArray())
                : $"{select}";
            Console.WriteLine($"SELECT result: {selectReport}");

            trans.Commit();
            conn.Disconnect();
        }
    }
}
