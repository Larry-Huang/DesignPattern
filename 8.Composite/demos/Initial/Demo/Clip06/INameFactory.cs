namespace Demo.Clip06
{
    public interface INameFactory
    {
        Name Anonymous { get; }
        Name Create(string first, params string[] others);
    }
}