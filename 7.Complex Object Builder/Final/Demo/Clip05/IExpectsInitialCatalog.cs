namespace Demo.Clip05
{
    interface IExpectsInitialCatalog
    {
        IExpectsAuthentication WithInitialCatalog(string initialCatalog);
    }
}