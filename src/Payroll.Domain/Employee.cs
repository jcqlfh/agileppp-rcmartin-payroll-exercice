namespace Payroll.Domain;

public class Employee
{
    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string Address { get; private set; }
    public PaymentType PaymentType { get; private set; }
    public decimal PaymentValue { get; private set; }
    public decimal Rate { get; set; }
    public Guid MemberId { get; private set; }
    public decimal UnionDueRate { get; private set; }
    public bool IsUnionized { get => !Guid.Empty.Equals(MemberId); }
    public PaymentMethod PaymentMethod { get; private set; }
    public string? PaymentAddress { get; private set; }
    public string? PaymentBank { get; private set; }
    public string? PaymentBankAccount { get; private set; }

    public Employee(string name, string address, PaymentType paymentType, decimal paymentValue, decimal rate = 0m)
    {
        if (string.IsNullOrEmpty(name))
            throw new ArgumentNullException("Name cannot be null or empty");
        
        if (string.IsNullOrEmpty(address))
            throw new ArgumentNullException("Address cannot be null or empty");

        if (paymentValue <= 0m)
            throw new ArgumentException("Payment value should be a positive number");
        
        if (paymentType == PaymentType.Commissioned && rate <= 0m)
            throw new ArgumentException("Commisioned employees should have a positive rate");

        this.Id = Guid.NewGuid();
        this.Name = name;
        this.Address = address;
        this.PaymentType = paymentType;
        this.PaymentValue = paymentValue;
        this.Rate = rate;
    }

    public void ChangeName(string newName)
    {
        if (string.IsNullOrEmpty(newName))
            throw new ArgumentNullException("Name cannot be null or empty");
        
        if (!newName.Equals(this.Name))
            this.Name = newName;
    }

    public void ChangeAddress(string newAddress)
    {
        if (string.IsNullOrEmpty(newAddress))
            throw new ArgumentNullException("Address cannot be null or empty");
        
        if (!newAddress.Equals(this.Address))
            this.Address = newAddress;    }
}
