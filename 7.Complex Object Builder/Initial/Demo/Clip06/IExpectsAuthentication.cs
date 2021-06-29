namespace Demo.Clip06
{
    interface IExpectsAuthentication
    {
        IOptionalsBuilder WithCredentials(string userId, string password);
        IOptionalsBuilder UsingIntegratedSecurity();
        IOptionalsBuilder UsingTrustedConnection();
    }
}