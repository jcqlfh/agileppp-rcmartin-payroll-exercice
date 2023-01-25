namespace Payroll.Domain;

public class ServiceCharge
{
    public Guid Id { get; private set; }
    public Guid MemberId { get; private set; }
    public DateOnly Date { get; private set; }
    public decimal Due { get; private set; }

    public ServiceCharge(Guid memberId, DateOnly date, decimal due)
    {
        if (Guid.Empty.Equals(memberId))
            throw new ArgumentException("Member Id cannot be empty");
        
        if (DateOnly.MaxValue.Equals(date) || DateOnly.MinValue.Equals(date))
            throw new ArgumentException("Date should have a valid value");
        
        if (due <= 0m)
            throw new ArgumentException("Due value should be a positive value");

        this.Id = Guid.NewGuid();
        this.MemberId = memberId;
        this.Date = date;
        this.Due = due;
    }
}