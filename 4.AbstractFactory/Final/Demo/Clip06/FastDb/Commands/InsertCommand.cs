using System;

namespace Demo.Clip06.FastDb.Commands
{
    class InsertCommand : Command<(object key, Type keyType)>
    {
        public InsertCommand(string commandText) : base(commandText)
        {
        }

        public override (object key, Type keyType) Execute(Transaction transaction) =>
            (17, typeof(int));
    }
}