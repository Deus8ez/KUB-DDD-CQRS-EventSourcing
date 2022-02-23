using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KUB.Infrastructure.Data.Repositories
{
    public abstract class BaseReadRepository
    {
        protected SqlConnection ConnectToDb(string connectionString)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
