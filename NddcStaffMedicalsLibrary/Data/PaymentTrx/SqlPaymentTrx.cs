using Microsoft.Extensions.Configuration;
using NddcStaffMedicalsLibrary.Databases;
using NddcStaffMedicalsLibrary.Model.OnlinePayment;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcStaffMedicalsLibrary.Data.PaymentTrx
{
    public class SqlPaymentTrx : IPaymentTrxData
    {
        private readonly ISqlDataAccess db;
        private readonly IConfiguration config;
        private const string connectionStringName = "SqlDb";

        public SqlPaymentTrx(ISqlDataAccess db)
        {
            this.db = db;
        }

        public bool TransactionExists(string trxReference)
        {
            string trxRef = db.LoadData<string, dynamic>("Select TrxRef From Transactions Where TrxRef = @TrxRef ", new { TrxRef = trxReference }, connectionStringName, false).FirstOrDefault();

            if (string.IsNullOrWhiteSpace(trxRef))
            {
                return false;
            }
            return true;
        }

        public void UpdateTrxStatus(string trxRef)
        {
            db.SaveData("Update Transactions Set Status = True Where TrxRef = @TrxRef", new { TrxRef = trxRef }, connectionStringName, false);
        }
    }
}
