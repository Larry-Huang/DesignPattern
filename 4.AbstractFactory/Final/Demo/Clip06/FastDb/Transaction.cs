using System;
using Demo.Clip06.Data;

namespace Demo.Clip06.FastDb
{
    class Transaction : ITransaction
    {
        private Guid Id { get; } = Guid.NewGuid();

        public void Commit() { }

        public void Rollback() { }

        public override string ToString() =>
            $"Transaction(Id={this.Id})";
    }
}