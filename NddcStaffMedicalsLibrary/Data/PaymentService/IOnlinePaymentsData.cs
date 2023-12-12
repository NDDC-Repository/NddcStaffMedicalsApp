using NddcStaffMedicalsLibrary.Model.OnlinePayment;
using PayStack.Net;

namespace NddcStaffMedicalsLibrary.Data.PaymentService
{
    public interface IOnlinePaymentsData
    {
        MyResponseModel MyResponse { get; set; }
        PayStackApi Paystack { get; set; }

        MyResponseModel ProcessPayment(MyPaymentModel payment);
        MyResponseModel Verify(string reference);
    }
}