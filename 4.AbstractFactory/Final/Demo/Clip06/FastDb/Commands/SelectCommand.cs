using System.Collections.Generic;

namespace Demo.Clip06.FastDb.Commands
{
    class SelectCommand : Command<IEnumerable<object>>
    {
        public SelectCommand(string commandText) : base(commandText)
        {
        }

        public override IEnumerable<object> Execute(Transaction transaction) =>
            new[] {"Jack", "Joe", "Jill"};
    }
}
