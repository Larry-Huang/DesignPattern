namespace Demo.Clip06.Names
{
    class SingleName : Name
    {
        public override string Printable { get; }
     
        public SingleName(string name)
        {
            this.Printable = name;
        }
    }
}