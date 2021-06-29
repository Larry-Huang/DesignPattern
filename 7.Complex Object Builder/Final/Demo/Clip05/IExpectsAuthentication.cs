namespace Demo.Clip05
{
    interface IExpectsAuthentication
    {
        IOptionalsBuilder WithCredentials(string userId, string password);
        IOptionalsBuilder UsingIntegratedSecurity();
        IOptionalsBuilder UsingTrustedConnection();
    }
}