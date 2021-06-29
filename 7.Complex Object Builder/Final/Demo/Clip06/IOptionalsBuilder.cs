namespace Demo.Clip06
{
    interface IOptionalsBuilder
    {
        IOptionalsBuilder WithConnectTimeout(int seconds);
        IOptionalsBuilder WithProvider(string provider);
        string Build();
    }
}