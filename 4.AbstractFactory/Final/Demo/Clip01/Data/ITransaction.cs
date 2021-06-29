namespace Demo.Clip01.Data
{
    public interface ITransaction
    {
        void Commit();
        void Rollback();
    }
}