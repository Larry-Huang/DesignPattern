namespace Demo.Clip05.Names
{
    class FirstEtAl : Name
    {
        private SingleName First { get; }
        
        public FirstEtAl(SingleName first)
        {
            this.First = first;
        }

        public override string Printable =>
            $"{this.First.Printable} et al.";
    }
}
