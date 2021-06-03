using MachineCafeDAL.Repositories;


namespace MachineCafe.BLL
{
    public static class ConnectionHelper
    {
        public static IConnectionFactory GetConnection()
        {
            return new DbConnectionFactory("connectionString");
        }
    }
}
