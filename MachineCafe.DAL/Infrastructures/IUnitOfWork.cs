namespace MachineCafeDAL.Repositories
{
    public interface IUnitOfWork
    {
        void Dispose();

        void SaveChanges();
    }
}
