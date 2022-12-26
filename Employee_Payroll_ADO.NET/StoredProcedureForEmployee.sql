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

--Retrieve Data By Given Name
CREATE PROCEDURE SPGetAllEmployeesByName(
@EmployeeName VARCHAR(30)
)
AS BEGIN
SELECT EmployeeName,CompanyName,Gender,EmployeeAddress,BasicPay,Deductions,TaxablePay,IncomeTax,NetPay,StartDate,DepartmentName
FROM Company 
INNER JOIN Employee ON Employee.CompanyID = Company.CompanyID 
INNER JOIN PayRoll ON PayRoll.EmployeeID = Employee.EmployeeID
INNER JOIN EmployeeDepartment ON EmployeeDepartment.EmployeeID = Employee.EmployeeID
INNER JOIN Department ON Department.DepartmentID = EmployeeDepartment.DepartmentID
WHERE EmployeeName=@EmployeeName
END

--Retrieve Data Btw Given Range
CREATE PROCEDURE SPEmployees_ForParticularRange
AS BEGIN
SELECT EmployeeName,CompanyName,Gender,EmployeeAddress,BasicPay,Deductions,TaxablePay,IncomeTax,NetPay,StartDate,DepartmentName
FROM Company
INNER JOIN Employee ON Employee.CompanyID = Company.CompanyID AND StartDate BETWEEN CAST('2017-09-15' AS DATE) AND GETDATE()
INNER JOIN PayRoll ON PayRoll.EmployeeID = Employee.EmployeeID
INNER JOIN EmployeeDepartment ON EmployeeDepartment.EmployeeID = Employee.EmployeeID
INNER JOIN Department ON Department.DepartmentID = EmployeeDepartment.DepartmentID
END

--Use Database Functions
CREATE PROCEDURE SPUsingDatabaseFunction
AS BEGIN
SELECT COUNT(*) AS NoOfContacts,MAX(BasicPay) AS MaximumSalary,MIN(BasicPay) AS MinimumSalary,AVG(BasicPay) AS AverageSalary,SUM(BasicPay) AS TotalSalary,Gender
FROM Company
INNER JOIN Employee ON Employee.CompanyID = Company.CompanyID
INNER JOIN PayRoll ON PayRoll.EmployeeID = Employee.EmployeeID
INNER JOIN EmployeeDepartment ON EmployeeDepartment.EmployeeID = Employee.EmployeeID
INNER JOIN Department ON Department.DepartmentID = EmployeeDepartment.DepartmentID
GROUP BY Gender
END