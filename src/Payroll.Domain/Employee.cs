namespace Payroll.Domain;

public class Employee
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public PaymentType PaymentType { get; private set; }
    public decimal PaymentValue { get; private set; }
    public bool IsUnionized { get; private set; }

    public Employee(string name, string address, PaymentType paymentType, decimal paymentValue, bool isUnionized = false)
    {
        this.Id = Guid.NewGuid();
        this.Name = name;
        this.Address = address;
        this.PaymentType = paymentType;
        this.PaymentValue = paymentValue;
        this.IsUnionized = isUnionized;
    }
}
