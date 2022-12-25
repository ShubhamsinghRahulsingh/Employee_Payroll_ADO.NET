using System;
namespace Employee_Payroll_ADO.NET
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Employee_Payroll Database with ADO.NET");
            EmployeeRepository employeeRepository = new EmployeeRepository();
            bool flag = true;
            while(flag)
            {
                Console.WriteLine("-------------------------------------------------");
                Console.WriteLine("Select From the Following\n1.Retrieve All Data From Database\n2.Exit");
                Console.Write("Enter Your Option:");
                int opt=Convert.ToInt32(Console.ReadLine());
                switch(opt)
                {
                    case 1:
                        employeeRepository.GetAllEmployees();
                        break;
                    case 2:
                        flag = false;
                        break;
                }
            }
        }
    }
}
