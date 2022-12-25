using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Employee_Payroll_ADO.NET
{
    public class Employee
    {
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }
        public string Gender { get; set; }
        public string EmployeeAddress { get; set; }
        public double BasicPay { get; set; }
        public double Deductions { get; set; }
        public double TaxablePay { get; set; }
        public double IncomeTax { get; set; }
        public double NetPay { get; set; }
        public DateTime StartDate { get; set; }
        public string DepartmentName { get; set; }
    }
}
