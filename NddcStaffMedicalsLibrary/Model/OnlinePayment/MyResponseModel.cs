using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcStaffMedicalsLibrary.Model.OnlinePayment
{
    public class MyResponseModel
    {
        public string AuthorizationUrl { get; set; }
        public string ErrorMsg { get; set; }
        public string Status { get; set; }
    }
}
