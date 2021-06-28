using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace LoadBD
{
    class Program
    {
        static void Main()
        {
            Random rnd = new Random();
            int CountDepartment = 20;
            int CountEmployee = 500;

            // Получить объект Connection подключенный к DB.
            SqlConnection connection = DBUtils.GetDBConnection();
            connection.Open();
            try
            {
                 string sql = "Insert into Department (Name, Description) "
                                                     + " values (@name, @description) ";
                SqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = sql;
                cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = "Без департамента";
                cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = "Сотрудники без департамента";

                // Выполнить Command (Используется для delete, insert, update).
                int rowCount = cmd.ExecuteNonQuery();
                // Команда Insert для Department.
                for (int i = 1; i <= CountDepartment; i++)
                { 
                    cmd = connection.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = "Департамент-" + i;
                    cmd.Parameters.Add("@description", SqlDbType.NVarChar).Value = "Описание-" + i;
                
                    // Выполнить Command (Используется для delete, insert, update).
                    rowCount = cmd.ExecuteNonQuery();
                }

                // Команда Insert для Employee.
                for (int i = 1; i <= CountEmployee; i++)
                {
                    sql = "Insert into Employee (Name, Suname, Age, Salary, PhoneNumber, DepartmentID) "
                                                     + " values (@name, @suname, @age, @salary, @phoneNumber, @departmentID) ";
                    cmd = connection.CreateCommand();
                    cmd.CommandText = sql;
                    cmd.Parameters.Add("@name", SqlDbType.NVarChar).Value = "Имя-" + i;
                    cmd.Parameters.Add("@suname", SqlDbType.NVarChar).Value = "Фамилия-" + i;
                    cmd.Parameters.Add("@age", SqlDbType.Int).Value = rnd.Next(18, 65);
                    cmd.Parameters.Add("@salary", SqlDbType.Int).Value = rnd.Next(50000, 150000);
                    cmd.Parameters.Add("@phoneNumber", SqlDbType.NVarChar).Value = rnd.Next(1000000, 9999999).ToString("000-00-00");
                    cmd.Parameters.Add("@departmentID", SqlDbType.Int).Value = rnd.Next(1, CountDepartment + 1);

                    // Выполнить Command (Используется для delete, insert, update).
                    rowCount = cmd.ExecuteNonQuery();
                }
                Console.WriteLine("База данных заполнена");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e.Message);
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                connection.Close();
                connection.Dispose();
            }

            Console.Read();
        }
    }
}
