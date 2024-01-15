using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NddcStaffMedicalsLibrary.Data.PaymentService;
using NddcStaffMedicalsLibrary.Model.OnlinePayment;

namespace NddcStaffMedicals.Web.Pages.Portal.Payments
{
    public class NewPaymentsModel : PageModel
    {
        private readonly IOnlinePaymentsData paystackDb;

        [BindProperty]
        public MyPaymentModel Payment { get; set; }
        public MyResponseModel Response { get; set; }
        public string Error { get; set; }

        public NewPaymentsModel(IOnlinePaymentsData paystackDb)
        {
            this.paystackDb = paystackDb;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPost()
        {
            Response = paystackDb.ProcessPayment(Payment);

            Error = Response.ErrorMsg;
            if (!string.IsNullOrEmpty(Error))
            {
                return Redirect(Response.AuthorizationUrl);
            }
            return Page();

        }
    }
}
