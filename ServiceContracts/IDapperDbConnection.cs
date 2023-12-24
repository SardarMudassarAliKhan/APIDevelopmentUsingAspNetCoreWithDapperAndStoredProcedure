using System.Data;

namespace APIDevelopmentUsingAspNetCoreWithDapperAndStoredProcedure.ServiceContracts
{
    public interface IDapperDbConnection
    {
        public IDbConnection CreateConnection();
    }
}
