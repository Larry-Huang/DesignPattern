using Demo.Clip05.Data;

namespace Demo.Clip05.CheapDb
{
    public class Command : ICommand
    {
        public string Text { get; }
     
        public Command(string text)
        {
            this.Text = text;
        }
    }
}
