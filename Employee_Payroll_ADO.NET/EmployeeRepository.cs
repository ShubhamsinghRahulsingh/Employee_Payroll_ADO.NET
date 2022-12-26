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
        public void GetAllEmployees()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);    // Establishing the connection using the Sqlconnection.
                List<Employee> employee = new List<Employee>();
                using (connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SPGetAllEmployees", connection);
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
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SPUpdateEmployeeSalary",connection);
                    command.CommandType = CommandType.StoredProcedure;
                    int result = command.ExecuteNonQuery();
                    connection.Close();
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
                SqlConnection connection = new SqlConnection(connectionString);
                List<Employee> employee = new List<Employee>();
                using (connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SPGetAllEmployeesByName", connection);
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
        public void GetAllEmployeesInPartiCularPeriod()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                List<Employee> employee = new List<Employee>();
                using (connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SPEmployees_ForParticularRange", connection);
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
                        Console.WriteLine("EmployeeName" + "  " + "CompanyName" + "  " + "Gender" + "  " + "EmployeeAddress" + "  " + "BasicPay" + "  " + "Deductions" + "  " + "TaxablePay" + "  " + "IncomeTax" + "     " + "NetPay" + "         " + "StartDate" + "        " + "DepartmentName");
                        foreach (var data in employee)
                        {
                            Console.WriteLine(data.EmployeeName + "           " + data.CompanyName + "          " + data.Gender + "     " + data.EmployeeAddress + "   " + data.BasicPay + "      " + data.Deductions + "      " + data.TaxablePay + "   " + data.IncomeTax + "     " + data.NetPay + "       " + data.StartDate + "      " + data.DepartmentName);
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not Find The Given Date");
                    }
                }
            }
            catch (Exception ex)
            {
                // handle exception here
                Console.WriteLine(ex.Message);
            }
        }
        public void UsingDatabaseFunctions()
        {
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                using (connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("SPUsingDatabaseFunction", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = command.ExecuteReader();
                    if (dr.HasRows)
                    {
                        Console.WriteLine("NoOfContacts:"+ "  MaximumSalary:  "+"  MinimumSalary:"+"  AverageSalary:"+"  TotalSalary:"+"  Gender:");
                        while (dr.Read())
                        {
                            Console.WriteLine(dr.GetInt32(0)+"          "+dr.GetDouble(1)+"          "+dr.GetDouble(2)+"       "+dr.GetDouble(3)+"         "+dr.GetDouble(4)+"        "+dr.GetDouble(5)+"        "+dr.GetString(6)); 
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not Find The Given Date");
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
