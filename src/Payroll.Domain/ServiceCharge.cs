using Payroll.Model;

namespace Payroll.Domain;

public class ServiceCharge
{
    public decimal Due { get; private set; }

    public ServiceCharge(decimal due)
    {   
        if (due <= 0m)
            throw new ArgumentException("Due value should be a positive value");

        this.Due = due;
    }
}