namespace Demo.Clip05.Data
{
    public interface ITransaction
    {
        void Commit();
        void Rollback();
    }
}