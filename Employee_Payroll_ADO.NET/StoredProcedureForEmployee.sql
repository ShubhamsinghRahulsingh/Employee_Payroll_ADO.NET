USE PAYROLL_SERVICES

--Fetching all details
CREATE PROCEDURE SPGetAllEmployees
AS BEGIN
SELECT EmployeeName,CompanyName,Gender,EmployeeAddress,BasicPay,Deductions,TaxablePay,IncomeTax,NetPay,StartDate,DepartmentName
FROM Company
INNER JOIN Employee ON Employee.CompanyID = Company.CompanyID 
INNER JOIN PayRoll ON PayRoll.EmployeeID = Employee.EmployeeID
INNER JOIN EmployeeDepartment ON EmployeeDepartment.EmployeeID = Employee.EmployeeID
INNER JOIN Department ON Department.DepartmentID = EmployeeDepartment.DepartmentID
END

--Updating BasicPay for Particular Employee
CREATE PROCEDURE SPUpdateEmployeeSalary
AS BEGIN
UPDATE PayRoll SET BasicPay=300000 WHERE EmployeeID=1
UPDATE PayRoll SET TaxablePay = (BasicPay - Deductions);
UPDATE PayRoll SET NetPay = (TaxablePay - IncomeTax);
END

