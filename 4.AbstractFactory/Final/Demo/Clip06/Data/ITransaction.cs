namespace Demo.Clip06.Data
{
    public interface ITransaction
    {
        void Commit();
        void Rollback();
    }
}