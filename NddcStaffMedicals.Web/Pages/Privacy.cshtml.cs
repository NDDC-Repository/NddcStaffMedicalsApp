using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcStaffMedicalsLibrary.Data.PaymentService;
using NddcStaffMedicalsLibrary.Model.OnlinePayment;

namespace NddcStaffMedicals.Web.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly IOnlinePaymentsData paystackDb;
        public MyResponseModel Response { get; set; }
        public MyResponseModel Verify { get; set; }

        public PrivacyModel(IOnlinePaymentsData paystackDb)
        {
            this.paystackDb = paystackDb;
        }

        public void OnGet(string reference)
        {
            Verify = paystackDb.Verify(reference);
        }
    }
}