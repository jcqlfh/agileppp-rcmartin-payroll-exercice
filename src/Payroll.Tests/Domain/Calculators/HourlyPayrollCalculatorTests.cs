using Xunit;
using Payroll.Domain;
using Payroll.Domain.Calculators;

namespace Payroll.Tests.Domain.Calculators;

public class HourlyPayrollCalculatorTests
{
    private Employee _employee;

    private HourlyPayrollCalculator _payroll;

    public HourlyPayrollCalculatorTests()
    {
        _employee = new Employee(
            "Name",
            "Address",
            PaymentType.Hourly,
            10
        );
        _payroll = new HourlyPayrollCalculator();
    }

    [Fact]
    public void Employee_Valid_Payment()
    {
        // Arrange
        var totalPayment = 260m;
        var paymentDate = new DateOnly(2023,01,27);

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
        var payment = _payroll.Calculate(paymentDate, _employee);
    
        // Assert
        Assert.NotNull(payment);
        Assert.Equal(totalPayment, payment?.PaymentValue);
    }

    [Fact]
    public void Employee_Valid_Unionized_Payment()
    {
        // Arrange
        var totalPayment = 200m;
        var paymentDate = new DateOnly(2023,01,27);

        var date1 = new DateOnly(2023,01,27);
        var hours1 = 7m;
        _employee.AddTimeCard(date1, hours1);

        var date2 = new DateOnly(2023,01,26);
        var hours2 = 8m;
        _employee.AddTimeCard(date2, hours2);

        var date3 = new DateOnly(2023,01,25);
        var hours3 = 10m;
        _employee.AddTimeCard(date3, hours3);

        var memberId = Guid.NewGuid();
        var unionRate = 1m/21m;
        _employee.AddToUnion(memberId, unionRate);

        var due = 50m;
        _employee.AddServiceCharge(due);

        // Act
        var payment = _payroll.Calculate(paymentDate, _employee);
    
        // Assert
        Assert.NotNull(payment);
        Assert.Equal(totalPayment, payment?.PaymentValue);
    }

    [Fact]
    public void Employee_Invalid_Payment_Date()
    {
        // Arrange
        var paymentDate = new DateOnly(2023,01,28);

        var date1 = new DateOnly(2023,01,27);
        var hours1 = 7m;
        _employee.AddTimeCard(date1, hours1);

        var date2 = new DateOnly(2023,01,26);
        var hours2 = 8m;
        _employee.AddTimeCard(date2, hours2);

        var date3 = new DateOnly(2023,01,25);
        var hours3 = 10m;
        _employee.AddTimeCard(date3, hours3);

        var memberId = Guid.NewGuid();
        var unionRate = 1m/21m;
        _employee.AddToUnion(memberId, unionRate);

        var due = 50m;
        _employee.AddServiceCharge(due);

        // Act
        var payroll = new HourlyPayrollCalculator();
        var payment = _payroll.Calculate(paymentDate, _employee);
    
        // Assert
        Assert.Null(payment);
    }

    [Fact]
    public void Employee_Invalid_Employee()
    {
        // Arrange
        var paymentDate = new DateOnly(2023,01,27);

        _employee.ChangeToMonthlyPayment(200);

        // Act
        var payment = () => _payroll.Calculate(paymentDate, _employee);
    
        // Assert
        Assert.Throws<InvalidOperationException>(payment);
    }
}