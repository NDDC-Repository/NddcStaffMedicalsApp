using NddcStaffMedicalsLibrary.Databases;
using NddcStaffMedicalsLibrary.Model.Lab;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcStaffMedicalsLibrary.Data.LabData
{
    public class SqlLabs : ILabsData
    {
        private const string connectionStringName = "SqlDb";
        private readonly ISqlDataAccess db;

        public SqlLabs(ISqlDataAccess db)
        {
            this.db = db;
        }

        public List<MyLabModel> GetAllApprovedLabs()
        {
            string SQL = "SELECT ROW_NUMBER() OVER (ORDER BY Id DESC) As SrNo, Id, LabName, LabType, State, City, CompanyPhone, CompanyEmail, Approved From Laboratories";
            return db.LoadData<MyLabModel, dynamic>(SQL, new { }, connectionStringName, false).ToList();
        }

        public MyLabModel GetLabDetails(int labId)
        {
            return db.LoadData<MyLabModel, dynamic>("Select City, ExminationCost Where Id = @Id", new { Id = labId }, connectionStringName, false).FirstOrDefault();
        }
    }
}
