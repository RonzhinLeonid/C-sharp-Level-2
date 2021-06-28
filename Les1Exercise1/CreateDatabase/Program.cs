using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CreateDatabase
{
    class Program
    {
        static void Main()
        {
            String str;
            //SqlConnection myConn = new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;" +
            //                                            "Initial Catalog=Demo;" +
            //                                            "Integrated Security=True;" +
            //                                            "Pooling=False");
            SqlConnection myConn = new SqlConnection("Server=localhost;Integrated security=SSPI;database=master");

            //str = "CREATE DATABASE MyDatabase";
            str = "CREATE DATABASE MyDatabase ON PRIMARY " +
                "(NAME = MyDatabase_Data, " +
                "FILENAME = 'C:\\MyDatabaseData.mdf', " +
                "SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) " +
                "LOG ON (NAME = MyDatabase_Log, " +
                "FILENAME = 'C:\\MyDatabaseLog.ldf', " +
                "SIZE = 1MB, " +
                "MAXSIZE = 5MB, " +
                "FILEGROWTH = 10%)";

            SqlCommand myCommand = new SqlCommand(str, myConn);
            try
            {
                myConn.Open();
                myCommand.ExecuteNonQuery();
                Console.WriteLine("DataBase is Created Successfully");
                //MessageBox.Show("DataBase is Created Successfully", "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                //MessageBox.Show(ex.ToString(), "MyProgram", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            finally
            {
                if (myConn.State == ConnectionState.Open)
                {
                    myConn.Close();
                }
            }
            Console.ReadKey();
        }
    }
}
