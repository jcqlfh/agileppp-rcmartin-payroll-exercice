using Xunit;
using Payroll.Domain;
using Payroll.Domain.Calculators;

namespace Payroll.Tests.Domain.Calculators;

public class HourlyPayrollCalculatorTests
{
    private Employee _employee;

    public HourlyPayrollCalculatorTests()
    {
        _employee = new Employee(
            "Name",
            "Address",
            PaymentType.Hourly,
            10
        );
    }

    [Fact]
    public void Employee_Valid_Payment()
    {
        // Arrange
        var date1 = new DateOnly(2023,01,27);
        var hours1 = 7m;
        _employee.AddTimeCard(date1, hours1);

        var date2 = new DateOnly(2023,01,26);
        var hours2 = 8m;
        _employee.AddTimeCard(date2, hours2);

        var date3 = new DateOnly(2023,01,25);
        var hours3 = 10m;
        _employee.AddTimeCard(date3, hours3);

        // Act
        var payroll = new HourlyPayrollCalculator();
        var payment = payroll.Calculate(date1, _employee);
    
        // Assert
        Assert.NotNull(payment);
        Assert.Equal((7 + 8 + 8 + (2 * 1.5m)) * _employee.PaymentValue, payment.PaymentValue);
    }
}