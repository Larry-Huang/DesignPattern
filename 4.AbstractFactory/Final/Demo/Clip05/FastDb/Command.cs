using Demo.Clip05.Data;

namespace Demo.Clip05.FastDb
{
    abstract class Command<TResult> : ICommand
    {
        private string CommandText { get; }

        public abstract TResult Execute(Transaction transaction);

        protected Command(string commandText)
        {
            this.CommandText = commandText;
        }
    }
}