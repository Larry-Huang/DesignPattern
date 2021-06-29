namespace Demo.Clip06.Volumes
{
    class SeparateVolume : Volume
    {
        public string Label { get; }
        public string Title { get; }

        public SeparateVolume(string label, string title)
        {
            this.Label = label;
            this.Title = title;
        }

        public override string GetLabel(string prefix, string suffix) =>
            string.Empty;
    }
}