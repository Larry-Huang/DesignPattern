namespace Demo.Clip01
{
    public class Video
    {
        public string Title { get; }
     
        public Video(string title)
        {
            this.Title = title;
        }

        public override string ToString() =>
            this.Title;
    }
}
