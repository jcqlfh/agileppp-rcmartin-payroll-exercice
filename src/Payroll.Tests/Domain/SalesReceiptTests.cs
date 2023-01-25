using Xunit;
using Payroll.Domain;

public class SalesReceiptTests
{
    [Fact]
    public void New_SalesReceipt()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var date = new DateOnly();
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