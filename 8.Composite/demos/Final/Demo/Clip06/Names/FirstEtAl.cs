namespace Demo.Clip06.Names
{
    class FirstEtAl : Name
    {
        private SingleName First { get; }

        public override string Printable => 
            $"{this.First.Printable} et al.";

        public FirstEtAl(SingleName first)
        {
            this.First = first;
        }
    }
}
