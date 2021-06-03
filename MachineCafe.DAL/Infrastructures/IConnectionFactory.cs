using System.Data;

namespace MachineCafeDAL.Repositories
{
    public interface IConnectionFactory
    {
        IDbConnection Create();
    }
}
