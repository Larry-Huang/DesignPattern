using Demo.Clip06.Data;

namespace Demo.Clip06.FastDb
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