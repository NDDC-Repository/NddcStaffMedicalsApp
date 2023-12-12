using NddcStaffMedicalsLibrary.Model.Lab;

namespace NddcStaffMedicalsLibrary.Data.LabData
{
    public interface ILabsData
    {
        List<MyLabModel> GetAllApprovedLabs();
        MyLabModel GetLabDetails(int labId);
    }
}