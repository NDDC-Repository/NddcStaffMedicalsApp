using NddcStaffMedicalsLibrary.Model.Patient;

namespace NddcStaffMedicalsLibrary.Data.EmployeeData
{
    public interface IEmployeeData
    {
        bool EmployeeCodeExists(string empCode);
        bool EmployeeIsVerified(EmployeeModel empCompare);
        EmployeeModel GetEmployeeDetails(int EmpId);
    }
}