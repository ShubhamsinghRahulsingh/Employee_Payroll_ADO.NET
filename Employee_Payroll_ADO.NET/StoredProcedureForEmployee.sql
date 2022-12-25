USE PAYROLL_SERVICES

CREATE PROCEDURE SPGetAllEmployees
AS BEGIN
SELECT EmployeeName,CompanyName,Gender,EmployeeAddress,BasicPay,Deductions,TaxablePay,IncomeTax,NetPay,StartDate,DepartmentName
FROM Company
INNER JOIN Employee ON Employee.CompanyID = Company.CompanyID 
INNER JOIN PayRoll ON PayRoll.EmployeeID = Employee.EmployeeID
INNER JOIN EmployeeDepartment ON EmployeeDepartment.EmployeeID = Employee.EmployeeID
INNER JOIN Department ON Department.DepartmentID = EmployeeDepartment.DepartmentID
END
