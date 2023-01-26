using Xunit;
using Payroll.Domain;

namespace Payroll.Tests.Domain;

public class ServiceChargeTests
{
    [Fact]
    public void New_ServiceCharge_With_No_Due()
    {
        // Arrange
        // Act
        Action instatiation = () => { var serviceCharge = new ServiceCharge(0); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_ServiceCharge()
    {
        // Arrange
        decimal due = 8;

        // Act
        var serviceCharge = new ServiceCharge(due);

        // Assert
        Assert.Equal(due, serviceCharge.Due);
    }
}