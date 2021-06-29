namespace Demo.Clip05.FastDb.Commands
{
    class DeleteCommand : Command<int>
    {
        public DeleteCommand(string commandText) : base(commandText)
        {
        }

        public override int Execute(Transaction transaction) => 1;
    }
}