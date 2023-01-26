namespace Payroll.Domain;

public class PaycheckSettings
{
    public PaymentMethod Method { get; private set; }
    public string? Address { get; private set; }
    public string? Bank { get; private set; }
    public string? BankAccount { get; private set; }

    public PaycheckSettings(PaymentMethod method, string? address = null, string? bank = null, string? bankAccount = null)
    {
        if (method.Equals(PaymentMethod.Mail) && string.IsNullOrEmpty(address))
            throw new ArgumentNullException("Payment address cannot be null or empty");

        if (method.Equals(PaymentMethod.Direct) && (string.IsNullOrEmpty(bank) || string.IsNullOrEmpty(bankAccount)))
            throw new ArgumentNullException("Payment bank and account cannot be null or empty");

        this.Method = method;
        this.Address = address;
        this.Bank = bank;
        this.BankAccount = bankAccount;
    }
}
