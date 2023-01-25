using Xunit;
using Payroll.Domain;

namespace Payroll.Tests.Domain;

public class SalesReceiptTests
{
    [Fact]
    public void New_SalesReceipt_With_No_EmployeeId()
    {
        // Arrange
        var date = new DateOnly();
        decimal amount = 10;

        // Act
        Action instatiation = () => { var salesReceipt = new SalesReceipt(Guid.Empty, date, amount); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_SalesReceipt_With_No_Date()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        decimal amount = 10;

        // Act
        Action instatiation = () => { var salesReceipt = new SalesReceipt(employeeId, DateOnly.MinValue, amount); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_SalesReceipt_With_No_Amount()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var date = new DateOnly();

        // Act
        Action instatiation = () => { var salesReceipt = new SalesReceipt(Guid.Empty, date, 0); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_SalesReceipt()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var date = DateOnly.FromDateTime(DateTime.Now);
        decimal amount = 10;

        // Act
        var salesReceipt = new SalesReceipt(employeeId, date, amount);

        // Assert
        Assert.NotEqual(Guid.Empty, salesReceipt.Id);
        Assert.Equal(employeeId, salesReceipt.EmployeeId);
        Assert.Equal(date, salesReceipt.Date);
        Assert.Equal(amount, salesReceipt.Amount);
    }
}