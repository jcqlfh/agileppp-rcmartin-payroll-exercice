using Xunit;
using Payroll.Domain;

namespace Payroll.Tests.Domain;

public class TimeCardTests
{
     [Fact]
    public void New_TimeCard_With_No_EmployeeId()
    {
        // Arrange
        var date = new DateOnly();
        decimal hoursWorked = 10;

        // Act
        Action instatiation = () => { var timeCard = new TimeCard(Guid.Empty, date, hoursWorked); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_TimeCard_With_No_Date()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        decimal hoursWorked = 10;

        // Act
        Action instatiation = () => { var timeCard = new TimeCard(employeeId, DateOnly.MinValue, hoursWorked); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_TimeCard_With_No_HoursWorked()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var date = new DateOnly();

        // Act
        Action instatiation = () => { var timeCard = new TimeCard(Guid.Empty, date, 0); };

        // Assert
        Assert.Throws<ArgumentException>(instatiation);
    }

    [Fact]
    public void New_TimeCard()
    {
        // Arrange
        var employeeId = Guid.NewGuid();
        var date = DateOnly.FromDateTime(DateTime.Now);
        decimal hoursWorked = 8;

        // Act
        var timeCard = new TimeCard(employeeId, date, hoursWorked);

        // Assert
        Assert.NotEqual(Guid.Empty, timeCard.Id);
        Assert.Equal(employeeId, timeCard.EmployeeId);
        Assert.Equal(date, timeCard.Date);
        Assert.Equal(hoursWorked, timeCard.HoursWorked);
    }
}