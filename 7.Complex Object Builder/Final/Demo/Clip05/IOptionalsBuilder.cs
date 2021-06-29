namespace Demo.Clip05
{
    interface IOptionalsBuilder
    {
        IOptionalsBuilder WithConnectTimeout(int seconds);
        IOptionalsBuilder WithProvider(string provider);
        string Build();
    }
}