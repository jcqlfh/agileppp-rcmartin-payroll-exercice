using Payroll.Model;

namespace Payroll.Domain;

public class TimeCard
{
    public DateOnly Date { get; private set; }
    public decimal HoursWorked { get; private set; }

    public TimeCard(DateOnly date, decimal hoursWorked)
    {
        if (DateOnly.MaxValue.Equals(date) || DateOnly.MinValue.Equals(date))
            throw new ArgumentException("Date should have a valid value");
        
        if (hoursWorked <= 0m)
            throw new ArgumentException("Hours worked should be a positive value");

        this.Date = date;
        this.HoursWorked = hoursWorked;
    }
}