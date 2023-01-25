namespace Payroll.Domain;

public class TimeCard
{
    public Guid EmployeeId { get; private set; }
    public DateOnly Date { get; private set; }
    public decimal HoursWorked { get; private set; }

    public TimeCard(Guid employeeId, DateOnly date, decimal hoursWorked)
    {
        this.EmployeeId = employeeId;
        this.Date = date;
        this.HoursWorked = hoursWorked;
    }
}