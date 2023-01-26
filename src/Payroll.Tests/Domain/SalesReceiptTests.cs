using Xunit;
using Payroll.Domain;

namespace Payroll.Tests.Domain;

public class SalesReceiptTests
{
    [Fact]
    public void New_SalesReceipt_With_No_Date()
    {
        // Arrange
        decimal amount = 10;

        // Act
        Action instatiation = () => { var salesReceipt = new SalesReceipt(DateOnly.MinValue, amount); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_SalesReceipt_With_No_Amount()
    {
        // Arrange
        var date = new DateOnly();

        // Act
        Action instatiation = () => { var salesReceipt = new SalesReceipt(date, 0); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_SalesReceipt()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Now);
        decimal amount = 10;

        // Act
        var salesReceipt = new SalesReceipt(date, amount);

        // Assert
        Assert.Equal(date, salesReceipt.Date);
        Assert.Equal(amount, salesReceipt.Amount);
    }
}