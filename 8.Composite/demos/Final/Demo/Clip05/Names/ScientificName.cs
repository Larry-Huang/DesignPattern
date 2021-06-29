namespace Demo.Clip05.Names
{
    class ScientificName : SingleName
    {
        public override string Printable =>
            this.Format(base.Printable.Split(' ', 2));

        private string Format(string[] segments) =>
            $"{segments[1]} {segments[0][0]}";

        public ScientificName(string name) : base(name)
        {
        }
    }
}
