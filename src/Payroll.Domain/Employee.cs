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
    public PaycheckSettings PaymentSettings { get; private set; }
    
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
        this.PaymentSettings = new PaycheckSettings(PaymentMethod.Hold);
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

    public void ChangeToHourlyPayment(decimal newPaymentValue)
    {
        if (newPaymentValue <= 0m)
            throw new ArgumentException("Payment value should be a positive number");

        this.PaymentType = PaymentType.Hourly;
        this.PaymentValue = newPaymentValue;
    }

    public void ChangeToMonthlyPayment(decimal newPaymentValue)
    {
        if (newPaymentValue <= 0m)
            throw new ArgumentException("Payment value should be a positive number");

        this.PaymentType = PaymentType.Monthly;
        this.PaymentValue = newPaymentValue;
    }

    public void ChangeToCommissionedPayment(decimal newPaymentValue, decimal newRate)
    {
        if (newPaymentValue <= 0m)
            throw new ArgumentException("Payment value should be a positive number");
        
        if (newRate <= 0m)
            throw new ArgumentException("Commisioned employees should have a positive rate");
        
        this.PaymentType = PaymentType.Commissioned;
        this.PaymentValue = newPaymentValue;
        this.Rate = newRate;
    }

    public void ChangeToMailPaymentMethod(string newMethodAddress)
    {
        this.PaymentSettings = new PaycheckSettings(PaymentMethod.Mail, newMethodAddress);
    }

    public void ChangeToHoldPaymentMethod()
    {
        this.PaymentSettings = new PaycheckSettings(PaymentMethod.Hold);
    }

    public void ChangeToDirectPaymentMethod(string newPaymentMethodBank, string newPaymentMethodBankAccount)
    {
        this.PaymentSettings = new PaycheckSettings(PaymentMethod.Direct, null, newPaymentMethodBank, newPaymentMethodBankAccount);
    }

    public void AddToUnion(Guid memberId, decimal unionRate)
    {
        if (Guid.Empty.Equals(memberId))
            throw new ArgumentException("Member id cannot be empty");
        
        if (unionRate <= 0m)
            throw new ArgumentException("Union due rate should be a positive number");
        
        this.MemberId = memberId;
        this.UnionDueRate = unionRate;
    }

    public void RemoveFromUnion()
    {
        this.MemberId = Guid.Empty;
        this.UnionDueRate = 0m;
    }
}
