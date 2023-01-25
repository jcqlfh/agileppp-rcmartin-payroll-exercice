using Xunit;
using Payroll.Domain;

public class TimeCardTests
{
    [Fact]
    public void New_TimeCard()
    {
        // Arrange
        var employeeId = new Guid();
        var date = new DateOnly();
        decimal hoursWorked = 8;

        // Act
        var timeCard = new TimeCard(employeeId, date, hoursWorked);

        // Assert
        Assert.Equal(employeeId, timeCard.EmployeeId);
        Assert.Equal(date, timeCard.Date);
        Assert.Equal(hoursWorked, timeCard.HoursWorked);
    }
}