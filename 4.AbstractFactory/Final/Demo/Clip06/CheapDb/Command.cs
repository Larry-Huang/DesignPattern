using Demo.Clip06.Data;

namespace Demo.Clip06.CheapDb
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
