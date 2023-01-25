using Xunit;

namespace Payroll.Tests;

public class UnitTest1
{
    [Fact]
    public void New_Employee()
    {
        // Arrange
        var name = "Employee";
        var address = "St Emplyee";
        var paymentType = PaymentType.Hourly;
        decimal paymentValue = 10;

        // Act
        var employee = new Employee(name, address, paymentType, paymentValue);

        // Assert
        Assert.Equal(name, employee.Name);
        Assert.Equal(address, employee.Address);
        Assert.Equal(paymentType, employee.PaymentType);
        Assert.Equal(paymentValue, employee.PaymentValue);
    }
}