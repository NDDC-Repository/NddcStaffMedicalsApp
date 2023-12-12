using NddcStaffMedicalsLibrary.Databases;
using NddcStaffMedicalsLibrary.Model.Patient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcStaffMedicalsLibrary.Data.EmployeeData
{
    public class SQLEmployee : IEmployeeData
    {
        private const string connectionStringName = "PayrollDB";
        private readonly ISqlDataAccess db;

        public SQLEmployee(ISqlDataAccess db)
        {
            this.db = db;
        }
        public EmployeeModel GetEmployeeDetails(int EmpId)
        {
            //string SQL2 = "SELECT Employees.EmployeeCode, Employees.Gender, Employees.MaritalStatus, Employees.FirstName, Employees.LastName, Employees.OtherNames, Employees.SpouseName, Employees.Email, Employees.Phone, Employees.DateOfBirth, Employees.Address, Employees.City, Employees.SID, Employees.Passport, Employees.EmploymentStatus, Employees.DateEngaged, Employees.ContactName, Employees.ContactPhone, Employees.Category, GradeLevel.GradeLevel, Departments.DepartmentName, JobTitles.Description FROM Employees LEFT JOIN GradeLevel ON Employees.GradeLevelId = GradeLevel.Id LEFT JOIN Departments ON Employees.DepartmentId = Departments.Id LEFT JOIN JobTitles ON Employees.JobTitleId = JobTitles.Id Where Id = @Id";
            string SQL = "SELECT Id, EmployeeCode, Gender, MaritalStatus, FirstName, LastName, OtherNames, SpouseName, Email, Phone, DateOfBirth, Address, City, SID, Passport, EmploymentStatus, DateEngaged, ContactName, ContactPhone from Employees Where Id = @Id";
            return db.LoadData<EmployeeModel, dynamic>(SQL, new { Id = EmpId }, connectionStringName, false).First();
        }
        public Boolean EmployeeCodeExists(string empCode)
        {
            string SQL = "Select EmployeeCode Where EmployeeCode = @Code";
            string MyEmpCode = db.LoadData<string, dynamic>(SQL, new { Code = empCode }, connectionStringName, false).FirstOrDefault();

            if (!string.IsNullOrEmpty(MyEmpCode))
            {
                return true;
            }

            return false;
        }
        public Boolean EmployeeIsVerified(EmployeeModel empCompare)
        {
            EmployeeModel employee = new();

            string SQL = "Select DateOfBirth, DateEngaged from Employees Where EmployeeCode = @Code";
            employee = db.LoadData<EmployeeModel, dynamic>(SQL, new { Code = empCompare.EmployeeCode }, connectionStringName, false).FirstOrDefault();

            if (empCompare.DateEngaged == employee.DateEngaged && empCompare.DateOfBirth == employee.DateOfBirth)
            {
                return true;
            }

            return false;
        }
    }
}
