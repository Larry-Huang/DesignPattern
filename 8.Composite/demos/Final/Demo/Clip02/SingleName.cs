namespace Demo.Clip02
{
    class SingleName : Name
    {
        public override string Printable{ get; }

        public SingleName(string name)
        {
            this.Printable = name;
        }
    }
}