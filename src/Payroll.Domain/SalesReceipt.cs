namespace Payroll.Domain;

public class SalesReceipt
{
    public Guid Id { get; private set; }
    public Guid EmployeeId { get; private set; }
    public DateOnly Date { get; private set; }
    public decimal Amount { get; private set; }

    public SalesReceipt(Guid employeeId, DateOnly date, decimal amount)
    {
        if (Guid.Empty.Equals(employeeId))
            throw new ArgumentException("Emplyee Id cannot be empty");
        
        if (DateOnly.MaxValue.Equals(date) || DateOnly.MinValue.Equals(date))
            throw new ArgumentException("Date should have a valid value");
        
        if (amount <= 0m)
            throw new ArgumentException("Amount should be a positive value");

        this.Id = Guid.NewGuid();
        this.EmployeeId = employeeId;
        this.Date = date;
        this.Amount = amount;
    }
}