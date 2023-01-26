using Xunit;
using Payroll.Domain;

namespace Payroll.Tests.Domain;

public class EmployeeTests
{
    [Fact]
    public void New_Employee_With_Empty_Name()
    {
        // Arrange
        var name = "";
        var address = "St Emplyee";
        var paymentType = PaymentType.Hourly;
        decimal paymentValue = 10;

        // Act
        Action instatiation = () => { var employee = new Employee(name, address, paymentType, paymentValue); };
        
        // Assert
        Assert.Throws<ArgumentNullException>(instatiation);
    }

    [Fact]
    public void New_Employee_With_Empty_Address()
    {
        // Arrange
        var name = "Emplyee";
        var address = "";
        var paymentType = PaymentType.Hourly;
        decimal paymentValue = 10;

        // Act
        Action instatiation = () => { var employee = new Employee(name, address, paymentType, paymentValue); };
        
        // Assert
        Assert.Throws<ArgumentNullException>(instatiation);
    }

    [Fact]
    public void New_Employee_With_Negative_PaymentValue()
    {
        // Arrange
        var name = "Emplyee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Hourly;
        decimal paymentValue = -10;

        // Act
        Action instatiation = () => { var employee = new Employee(name, address, paymentType, paymentValue); };
        
        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_Employee_Hourly()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Hourly;
        decimal paymentValue = 10;
        decimal rate = 0;

        // Act
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(rate, employee.Rate);
    }

    [Fact]
    public void New_Employee_Monthly()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000;
        decimal rate = 0;

        // Act
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(rate, employee.Rate);
    }

    [Fact]
    public void New_Employee_Commisioned()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Commissioned;
        decimal paymentValue = 1000;
        decimal rate = 10;

        // Act
        var employee = new Employee(name, address, paymentType, paymentValue, rate);

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(rate, employee.Rate);
    }

    [Fact]
    public void New_Employee_Commisioned_With_No_Rate()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Commissioned;
        decimal paymentValue = 1000;

        // Act
        Action instatiation = () => { var employee = new Employee(name, address, paymentType, paymentValue); };
        
        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void Employee_Change_Valid_Name()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newName = "NewName";
        employee.ChangeName(newName);

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(newName, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
    }

    [Fact]
    public void Employee_Change_Invalid_Name()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newName = "";
        Action changeName = () => employee.ChangeName(newName);

        // Assert
        Assert.Throws<ArgumentNullException>(changeName);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
    }

    [Fact]
    public void Employee_Change_Valid_Address()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newAddress = "NewAdress";
        employee.ChangeAddress(newAddress);

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(newAddress, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
    }

    [Fact]
    public void Employee_Change_Invalid_Address()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newAddress = "";
        Action changeAddress = () => employee.ChangeAddress(newAddress);

        // Assert
        Assert.Throws<ArgumentNullException>(changeAddress);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
    }

    [Fact]
    public void Employee_Monthly_Changed_To_Valid_Hourly_Value()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000m;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newPaymentType = PaymentType.Hourly;
        var newPaymentValue = 10m; 
        employee.ChangeToHourlyPayment(newPaymentValue);

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(newPaymentType, employee.PaymentType);
        Assert.Equal(newPaymentValue, employee.PaymentValue);
    }

    [Fact]
    public void Employee_Monthly_Changed_To_Invalid_Hourly_Value()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newPaymentValue = 0m; 
        Action changeHourly = () => employee.ChangeToHourlyPayment(newPaymentValue);;

        // Assert
        Assert.Throws<ArgumentException>(changeHourly);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
    }

    [Fact]
    public void Employee_Hourly_Changed_To_Valid_Monthly_Value()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Hourly;
        decimal paymentValue = 10m;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newPaymentType = PaymentType.Monthly;
        var newPaymentValue = 1000m; 
        employee.ChangeToMonthlyPayment(newPaymentValue);

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(newPaymentType, employee.PaymentType);
        Assert.Equal(newPaymentValue, employee.PaymentValue);
    }

    [Fact]
    public void Employee_Hourly_Changed_To_Invalid_Monthly_Value()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Hourly;
        decimal paymentValue = 10m;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newPaymentValue = 0m; 
        Action changeMonthly = () => employee.ChangeToMonthlyPayment(newPaymentValue);;

        // Assert
        Assert.Throws<ArgumentException>(changeMonthly);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
    }

    [Fact]
    public void Employee_Monthly_Changed_To_Valid_Comissioned_Values()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000m;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newPaymentType = PaymentType.Commissioned;
        var newPaymentValue = 1000m;
        var newRate = 10m;
        employee.ChangeToCommissionedPayment(newPaymentValue, newRate);

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(newPaymentType, employee.PaymentType);
        Assert.Equal(newPaymentValue, employee.PaymentValue);
        Assert.Equal(newRate, employee.Rate);
    }

    [Fact]
    public void Employee_Monthly_Changed_To_Invalid_Comissioned_Payment_Value()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Hourly;
        decimal paymentValue = 10m;
        decimal rate = 0;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newPaymentValue = 0m;
        var newRate = 10m;
        Action changeCommisioned = () => employee.ChangeToCommissionedPayment(newPaymentValue, newRate);

        // Assert
        Assert.Throws<ArgumentException>(changeCommisioned);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(rate, employee.Rate);
    }

    [Fact]
    public void Employee_Monthly_Changed_To_Invalid_Comissioned_Rate_Value()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Hourly;
        decimal paymentValue = 10m;
        decimal rate = 0;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newPaymentValue = 1000m;
        var newRate = 0m;
        Action changeCommisioned = () => employee.ChangeToCommissionedPayment(newPaymentValue, newRate);

        // Assert
        Assert.Throws<ArgumentException>(changeCommisioned);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(rate, employee.Rate);
    }

    [Fact]
    public void Employee_On_Hold_Changed_To_Valid_Mail_Payment_Method()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000m;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newPaymentMethod = PaymentMethod.Mail;
        var newMethodAddress = "Address";
        employee.ChangeToMailPaymentMethod(newMethodAddress);

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(newPaymentMethod, employee.PaymentMethod);
    }

    [Fact]
    public void Employee_On_Hold_Changed_To_Invalid_Mail_Payment_Method()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000m;
        var paymentMethod = PaymentMethod.Hold;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newMethodAddress = "";
        Action changePaymentMethod = () => employee.ChangeToMailPaymentMethod(newMethodAddress);

        // Assert
        Assert.Throws<ArgumentNullException>(changePaymentMethod);
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(paymentMethod, employee.PaymentMethod);
    }

    [Fact]
    public void Employee_On_Mail_Changed_To_Valid_Hold_Payment_Method()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000m;
        
        var employee = new Employee(name, address, paymentType, paymentValue);
        
        var paymentMethodAddress = "Address";
        employee.ChangeToMailPaymentMethod(paymentMethodAddress);

        // Act
        var newPaymentMethod = PaymentMethod.Hold;
        employee.ChangeToHoldPaymentMethod();

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(newPaymentMethod, employee.PaymentMethod);
    }

    [Fact]
    public void Employee_On_Hold_Changed_To_Valid_Direct_Payment_Method()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000m;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newPaymentMethod = PaymentMethod.Direct;
        var newPaymentMethodBank = "Bank";
        var newPaymentMethodBankAccount = "Account";
        employee.ChangeToDirectPaymentMethod(newPaymentMethodBank, newPaymentMethodBankAccount);

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(newPaymentMethod, employee.PaymentMethod);
        Assert.Equal(newPaymentMethodBank, employee.PaymentBank);
        Assert.Equal(newPaymentMethodBankAccount, employee.PaymentBankAccount);
    }

    [Fact]
    public void Employee_On_Hold_Changed_To_Invalid_Direct_Payment_Method_Bank()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000m;
        var paymentMethod = PaymentMethod.Hold;
        string? bank = null;
        string? account = null;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newPaymentMethodBank = "";
        var newPaymentMethodBankAccount = "Account";
        Action changePaymentMethod = () => employee.ChangeToDirectPaymentMethod(newPaymentMethodBank, newPaymentMethodBankAccount);

        // Assert
        Assert.Throws<ArgumentNullException>(changePaymentMethod);
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(paymentMethod, employee.PaymentMethod);
        Assert.Equal(bank, employee.PaymentBank);
        Assert.Equal(account, employee.PaymentBankAccount);
    }

    [Fact]
    public void Employee_On_Hold_Changed_To_Invalid_Direct_Payment_Method_BankAccount()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000m;
        var paymentMethod = PaymentMethod.Hold;
        string? bank = null;
        string? account = null;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var newPaymentMethodBank = "Bank";
        var newPaymentMethodBankAccount = "";
        Action changePaymentMethod = () => employee.ChangeToDirectPaymentMethod(newPaymentMethodBank, newPaymentMethodBankAccount);

        // Assert
        Assert.Throws<ArgumentNullException>(changePaymentMethod);
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(paymentMethod, employee.PaymentMethod);
        Assert.Equal(bank, employee.PaymentBank);
        Assert.Equal(account, employee.PaymentBankAccount);
    }

    [Fact]
    public void Employee_Not_Unionized_Changed_To_Valid_Union_Setting()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000m;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var memberId = Guid.NewGuid();
        decimal unionRate = 10m;
        employee.AddToUnion(memberId, unionRate);

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(memberId, employee.MemberId);
        Assert.Equal(unionRate, employee.UnionDueRate);
        Assert.True(employee.IsUnionized);
    }

    [Fact]
    public void Employee_Not_Unionized_Changed_To_Invalid_Union_MemberId()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000m;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var memberId = new Guid();
        decimal unionRate = 10m;
        Action addToUnion = () => employee.AddToUnion(memberId, unionRate);

        // Assert
        Assert.Throws<ArgumentException>(addToUnion);
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(memberId, employee.MemberId);
        Assert.Equal(0m, employee.UnionDueRate);
        Assert.False(employee.IsUnionized);
    }

    [Fact]
    public void Employee_Not_Unionized_Changed_To_Invalid_Union_DueRate()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000m;
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Act
        var memberId = Guid.NewGuid();
        decimal unionRate = -10m;
        Action addToUnion = () => employee.AddToUnion(memberId, unionRate);

        // Assert
        Assert.Throws<ArgumentException>(addToUnion);
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(Guid.Empty, employee.MemberId);
        Assert.Equal(0m, employee.UnionDueRate);
        Assert.False(employee.IsUnionized);
    }

    [Fact]
    public void Employee_Unionized_Changed_To_Valid_Non_Union_Setting()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Monthly;
        decimal paymentValue = 1000m;
        var employee = new Employee(name, address, paymentType, paymentValue);

        var memberId = Guid.NewGuid();
        decimal unionRate = 10m;
        employee.AddToUnion(memberId, unionRate);
        
        // Act
        employee.RemoveFromUnion();

        // Assert
        Assert.NotEqual(Guid.Empty, employee.Id);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
        Assert.Equal(Guid.Empty, employee.MemberId);
        Assert.Equal(0, employee.UnionDueRate);
        Assert.False(employee.IsUnionized);
    }
}