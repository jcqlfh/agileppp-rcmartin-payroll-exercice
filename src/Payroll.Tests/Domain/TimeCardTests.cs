using Xunit;
using Payroll.Domain;

namespace Payroll.Tests.Domain;

public class TimeCardTests
{
    [Fact]
    public void New_TimeCard_With_No_Date()
    {
        // Arrange
        decimal hoursWorked = 10;

        // Act
        Action instatiation = () => { var timeCard = new TimeCard(DateOnly.MinValue, hoursWorked); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_TimeCard_With_No_HoursWorked()
    {
        // Arrange
        var date = new DateOnly();

        // Act
        Action instatiation = () => { var timeCard = new TimeCard(date, 0); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_TimeCard()
    {
        // Arrange
        var date = DateOnly.FromDateTime(DateTime.Now);
        decimal hoursWorked = 8;

        // Act
        var timeCard = new TimeCard(date, hoursWorked);

        // Assert
        Assert.Equal(date, timeCard.Date);
        Assert.Equal(hoursWorked, timeCard.HoursWorked);
    }
}