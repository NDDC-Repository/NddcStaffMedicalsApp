using Microsoft.Extensions.Configuration;
using NddcStaffMedicalsLibrary.Data.PaymentTrx;
using NddcStaffMedicalsLibrary.Model.OnlinePayment;
using PayStack.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NddcStaffMedicalsLibrary.Data.PaymentService
{
    public class SqlPayStack : IOnlinePaymentsData
    {
        private readonly IConfiguration config;
        private readonly IPaymentTrxData transaction;
        private readonly string token;

        public MyResponseModel MyResponse { get; set; }

        public PayStackApi Paystack { get; set; }
        public SqlPayStack(IConfiguration config, IPaymentTrxData transaction)
        {
            this.config = config;
            this.transaction = transaction;
            token = config.GetConnectionString("PaystackSK");
            Paystack = new PayStackApi(token);
            MyResponse = new MyResponseModel();
        }
        public MyResponseModel ProcessPayment(MyPaymentModel payment)
        {
            TransactionInitializeRequest request = new()
            {
                AmountInKobo = payment.Amount * 100,
                Email = payment.Email,
                Reference = Generate().ToString(),
                Currency = "NGN",
                CallbackUrl = "https://localhost:7194/Staff/Payments/Verify"
            };

            TransactionInitializeResponse response = Paystack.Transactions.Initialize(request);
            if (response.Status)
            {
                var transaction = new MyTransactionModel()
                {
                    Amount = payment.Amount,
                    Email = payment.Email,
                    TrxRef = request.Reference,
                    Name = payment.Name,
                };
                MyResponse.AuthorizationUrl = response.Data.AuthorizationUrl;
                MyResponse.ErrorMsg = response.Message;
                return MyResponse;
            }

            MyResponse.ErrorMsg = response.Message;

            return MyResponse;
        }

        public MyResponseModel Verify(string reference)
        {
            MyResponseModel nResponse = new();

            TransactionVerifyResponse response = Paystack.Transactions.Verify(reference);
            if (response.Data.Status == "success")
            {
                ////var transaction = _context.Transactions.Where(x => x.TrxRef == reference).FirstOrDefault(); - Update Transactions and payments databases
                //if (transaction.TransactionExists(reference))
                //{
                //    transaction.Status = true;
                //    _context.Transactions.Update(transaction);
                //    await _context.SaveChangesAsync();
                //    return RedirectToAction("Donations");
                //}
                nResponse.Status = "success";
                return nResponse;
            }

            nResponse.ErrorMsg = response.Data.GatewayResponse;
            return nResponse;
        }
        public static int Generate()
        {
            Random rand = new Random((int)DateTime.Now.Ticks);
            return rand.Next(100000000, 999999999);
        }
    }
}
