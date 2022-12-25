using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Payroll_ADO.NET
{
    public class EmployeeRepository
    {
        //Specifying the connection string from the sql server connection.
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PAYROLL_SERVICES;Integrated Security=true;";  
        SqlConnection connection = new SqlConnection(connectionString);    // Establishing the connection using the Sqlconnection.
        public void DatabaseConnection()
        {
            try
            {
                //DateTime.Now class access system date and time 
                // Get current DateTime. It can be any DateTime object in your code.  
                DateTime now = DateTime.Now;          //create object DateTime class 
                connection.Open();                   // open connection
                using (this.connection)             //using SqlConnection
                {
                    Console.WriteLine($"Connection is created Successful on {now}");
                } 
                connection.Close();                 //close connection
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);     // handle exception here
            }
        }
    }
}
