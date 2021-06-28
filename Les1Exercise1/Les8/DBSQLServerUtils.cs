using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Les8
{
    class DBSQLServerUtils
    {
        public static SqlConnection
        GetDBConnection(string datasource, string database)
        {
            string connString = @"Data Source=" + datasource + ";Initial Catalog="
                        + database + ";Persist Security Info=True;Pooling=False";

            SqlConnection conn = new SqlConnection(connString);

            return conn;
        }
    }
}
