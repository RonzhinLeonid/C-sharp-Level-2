﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace LoadBD
{
    class DBUtils
    {
        public static SqlConnection GetDBConnection()
        {
            string datasource = @"(localdb)\MSSQLLocalDB";

            string database = "RonzhinL";

            return DBSQLServerUtils.GetDBConnection(datasource, database);
        }
    }
}
