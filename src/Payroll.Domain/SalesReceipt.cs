using Payroll.Model;

namespace Payroll.Domain;

public class SalesReceipt
{
    public DateOnly Date { get; private set; }
    public decimal Amount { get; private set; }

    public SalesReceipt(DateOnly date, decimal amount)
    {
        if (DateOnly.MaxValue.Equals(date) || DateOnly.MinValue.Equals(date))
            throw new ArgumentException("Date should have a valid value");
        
        if (amount <= 0m)
            throw new ArgumentException("Amount should be a positive value");

        this.Date = date;
        this.Amount = amount;
    }
}