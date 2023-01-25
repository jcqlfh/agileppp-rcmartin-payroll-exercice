namespace Payroll.Domain;

public class TimeCard
{
    public Guid Id { get; private set; }

    public Guid EmployeeId { get; private set; }
    public DateOnly Date { get; private set; }
    public decimal HoursWorked { get; private set; }

    public TimeCard(Guid employeeId, DateOnly date, decimal hoursWorked)
    {
        this.Id = Guid.NewGuid();
        this.EmployeeId = employeeId;
        this.Date = date;
        this.HoursWorked = hoursWorked;
    }
}