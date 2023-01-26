using Payroll.Model;

namespace Payroll.Domain;

public class ServiceCharge : IEntity
{
    public Guid Id { get; private set; }
    public Guid MemberId { get; private set; }
    public decimal Due { get; private set; }

    public ServiceCharge(Guid memberId, decimal due)
    {
        if (Guid.Empty.Equals(memberId))
            throw new ArgumentException("Member Id cannot be empty");
        
        if (due <= 0m)
            throw new ArgumentException("Due value should be a positive value");

        this.Id = Guid.NewGuid();
        this.MemberId = memberId;
        this.Due = due;
    }
}