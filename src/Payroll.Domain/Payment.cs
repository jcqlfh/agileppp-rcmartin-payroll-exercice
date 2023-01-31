namespace Payroll.Domain
{
    public class Payment
    {
        public DateOnly PaymentDate { get; private set; }
        public decimal PaymentValue { get; private set; }

        public Payment(DateOnly paymentDate, decimal paymentValue)
        {
            this.PaymentDate = paymentDate;
            this.PaymentValue = paymentValue;
        }

    }
}