using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Payroll_ADO.NET
{
    public class EmployeeRepository
    {
        //Specifying the connection string from the sql server connection.
        public static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=PAYROLL_SERVICES;Integrated Security=true;";
        SqlConnection connection = new SqlConnection(connectionString);    // Establishing the connection using the Sqlconnection.
        public void GetAllEmployees()
        {
            try
            {
                List<Employee> employee = new List<Employee>();
                using (this.connection)
                {
                    this.connection.Open();
                    SqlCommand command = new SqlCommand("SPGetAllEmployees", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Employee emp = new Employee();
                            emp.EmployeeName = dr.GetString(0);
                            emp.CompanyName = dr.GetString(1);
                            emp.Gender = dr.GetString(2);
                            emp.EmployeeAddress = dr.GetString(3);
                            emp.BasicPay = dr.GetDouble(4);
                            emp.Deductions = dr.GetDouble(5);
                            emp.TaxablePay = dr.GetDouble(6);
                            emp.IncomeTax = dr.GetDouble(7);
                            emp.NetPay = dr.GetDouble(8);
                            emp.StartDate = dr.GetDateTime(9);
                            emp.DepartmentName = dr.GetString(10);
                            employee.Add(emp);
                        }
                        Console.WriteLine("EmployeeName" + "  "+ "CompanyName"+"  "+ "Gender"+"  "+ "EmployeeAddress"+"  "+ "BasicPay"+"  "+ "Deductions"+"  "+ "TaxablePay"+"  "+ "IncomeTax"+"     "+ "NetPay"+"         "+ "StartDate"+"        "+ "DepartmentName");
                        foreach (var data in employee)
                        {
                            Console.WriteLine(data.EmployeeName + "           " + data.CompanyName + "          " + data.Gender +"     " + data.EmployeeAddress + "   " + data.BasicPay +"      " + data.Deductions +"      " + data.TaxablePay +"   " + data.IncomeTax +"     " + data.NetPay+"       "+data.StartDate+"      "+data.DepartmentName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Database Found");
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
        public void UpdateEmployeeSalary()
        {
            try
            {
                using (this.connection)
                {
                    this.connection.Open();
                    SqlCommand command = new SqlCommand("SPUpdateEmployeeSalary", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    int result = command.ExecuteNonQuery();
                    this.connection.Close();
                    if (result >= 1)
                    {
                        Console.WriteLine("Employee BasicPay Updated Successfully");
                    }
                    else
                        Console.WriteLine("Updation Failed");
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
        public void GetAllEmployeesByName(string name)
        {
            try
            {
                List<Employee> employee = new List<Employee>();
                using (this.connection)
                {
                    this.connection.Open();
                    SqlCommand command = new SqlCommand("SPGetAllEmployeesByName", this.connection);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@EmployeeName", name);
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Employee emp = new Employee();
                            emp.EmployeeName = dr.GetString(0);
                            emp.CompanyName = dr.GetString(1);
                            emp.Gender = dr.GetString(2);
                            emp.EmployeeAddress = dr.GetString(3);
                            emp.BasicPay = dr.GetDouble(4);
                            emp.Deductions = dr.GetDouble(5);
                            emp.TaxablePay = dr.GetDouble(6);
                            emp.IncomeTax = dr.GetDouble(7);
                            emp.NetPay = dr.GetDouble(8);
                            emp.StartDate = dr.GetDateTime(9);
                            emp.DepartmentName = dr.GetString(10);
                            employee.Add(emp);
                        }
                        Console.WriteLine("EmployeeName" + "  " + "CompanyName" + "  " + "Gender" + "  " + "EmployeeAddress" + "  " + "BasicPay" + "  " + "Deductions" + "  " + "TaxablePay" + "  " + "IncomeTax" + "     " + "NetPay" + "         " + "StartDate" + "        " + "DepartmentName");
                        foreach (var data in employee)
                        {
                            Console.WriteLine(data.EmployeeName + "           " + data.CompanyName + "          " + data.Gender + "     " + data.EmployeeAddress + "   " + data.BasicPay + "      " + data.Deductions + "      " + data.TaxablePay + "   " + data.IncomeTax + "     " + data.NetPay + "       " + data.StartDate + "      " + data.DepartmentName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("No Database Found");
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
    }
}
