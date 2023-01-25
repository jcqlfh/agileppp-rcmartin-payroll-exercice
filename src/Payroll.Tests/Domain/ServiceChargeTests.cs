using Xunit;
using Payroll.Domain;

namespace Payroll.Tests.Domain;

public class ServiceChargeTests
{
    [Fact]
    public void New_ServiceCharge_With_No_MemberId()
    {
        // Arrange
        decimal due = 10m;

        // Act
        Action instatiation = () => { var serviceCharge = new ServiceCharge(Guid.Empty, due); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_ServiceCharge_With_No_Due()
    {
        // Arrange
        var memberId = Guid.NewGuid();

        // Act
        Action instatiation = () => { var serviceCharge = new ServiceCharge(memberId, 0); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_ServiceCharge()
    {
        // Arrange
        var memberId = Guid.NewGuid();
        decimal due = 8;

        // Act
        var serviceCharge = new ServiceCharge(memberId, due);

        // Assert
        Assert.NotEqual(Guid.Empty, serviceCharge.Id);
        Assert.Equal(memberId, serviceCharge.MemberId);
        Assert.Equal(due, serviceCharge.Due);
    }
}