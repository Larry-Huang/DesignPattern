namespace Demo.Clip06
{
    interface IExpectsInitialCatalog
    {
        IExpectsAuthentication WithInitialCatalog(string initialCatalog);
    }
}