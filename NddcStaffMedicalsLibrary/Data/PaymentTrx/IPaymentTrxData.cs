namespace NddcStaffMedicalsLibrary.Data.PaymentTrx
{
    public interface IPaymentTrxData
    {
        bool TransactionExists(string trxReference);
        void UpdateTrxStatus(string trxRef);
    }
}