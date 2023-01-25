namespace Payroll.Domain;

public class TimeCard
{
    public Guid Id { get; private set; }
    public Guid EmployeeId { get; private set; }
    public DateOnly Date { get; private set; }
    public decimal HoursWorked { get; private set; }

    public TimeCard(Guid employeeId, DateOnly date, decimal hoursWorked)
    {
        if (Guid.Empty.Equals(employeeId))
            throw new ArgumentException("Emplyee Id cannot be empty");
        
        if (DateOnly.MaxValue.Equals(date) || DateOnly.MinValue.Equals(date))
            throw new ArgumentException("Date should have a valid value");
        
        if (hoursWorked <= 0m)
            throw new ArgumentException("Hours worked should be a positive value");

        this.Id = Guid.NewGuid();
        this.EmployeeId = employeeId;
        this.Date = date;
        this.HoursWorked = hoursWorked;
    }
}