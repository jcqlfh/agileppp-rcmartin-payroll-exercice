namespace Payroll.Domain;

public class SalesReceipt
{
    public Guid Id { get; private set; }
    public Guid EmployeeId { get; private set; }
    public DateOnly Date { get; private set; }
    public decimal Amount { get; private set; }

    public SalesReceipt(Guid employeeId, DateOnly date, decimal amount)
    {
        this.Id = Guid.NewGuid();
        this.EmployeeId = employeeId;
        this.Date = date;
        this.Amount = amount;
    }
}