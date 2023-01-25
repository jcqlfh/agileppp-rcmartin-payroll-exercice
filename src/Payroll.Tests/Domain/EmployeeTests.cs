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
        employee.ChangeToHourly(newPaymentValue);

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
        Action changeHourly = () => employee.ChangeToHourly(newPaymentValue);;

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
        employee.ChangeToMonthly(newPaymentValue);

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
        Action changeMonthly = () => employee.ChangeToMonthly(newPaymentValue);;

        // Assert
        Assert.Throws<ArgumentException>(changeMonthly);
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
    }
}