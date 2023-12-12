using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcStaffMedicalsLibrary.Model.OnlinePayment
{
    public class MyTransactionModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Amount { get; set; }
        public string TrxRef { get; set; }
        public string Email { get; set; }
        public Boolean Status { get; set; }
        public int LabId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
