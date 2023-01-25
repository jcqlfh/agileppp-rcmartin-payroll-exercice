using Xunit;
using Payroll.Domain;

namespace Payroll.Tests.Domain;

public class ServiceChargeTests
{
     [Fact]
    public void New_ServiceCharge_With_No_MemberId()
    {
        // Arrange
        var date = new DateOnly();
        decimal due = 10m;

        // Act
        Action instatiation = () => { var serviceCharge = new ServiceCharge(Guid.Empty, date, due); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_ServiceCharge_With_No_Date()
    {
        // Arrange
        var memberId = Guid.NewGuid();
        decimal due = 10m;

        // Act
        Action instatiation = () => { var serviceCharge = new ServiceCharge(memberId, DateOnly.MinValue, due); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_ServiceCharge_With_No_Due()
    {
        // Arrange
        var memberId = Guid.NewGuid();
        var date = new DateOnly();

        // Act
        Action instatiation = () => { var serviceCharge = new ServiceCharge(memberId, date, 0); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_ServiceCharge()
    {
        // Arrange
        var memberId = Guid.NewGuid();
        var date = DateOnly.FromDateTime(DateTime.Now);
        decimal due = 8;

        // Act
        var serviceCharge = new ServiceCharge(memberId, date, due);

        // Assert
        Assert.NotEqual(Guid.Empty, serviceCharge.Id);
        Assert.Equal(memberId, serviceCharge.MemberId);
        Assert.Equal(date, serviceCharge.Date);
        Assert.Equal(due, serviceCharge.Due);
    }
}