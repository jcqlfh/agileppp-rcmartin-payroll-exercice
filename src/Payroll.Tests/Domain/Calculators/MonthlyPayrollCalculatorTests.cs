using Xunit;
using Payroll.Domain;
using Payroll.Domain.Calculators;

namespace Payroll.Tests.Domain.Calculators;

public class MonthlyPayrollCalculatorTests
{
    private Employee _employee;

    private MonthlyPayrollCalculator _payroll;

    public MonthlyPayrollCalculatorTests()
    {
        _employee = new Employee(
            "Name",
            "Address",
            PaymentType.Monthly,
            1000
        );
        _payroll = new MonthlyPayrollCalculator();
    }

    [Fact]
    public void Employee_Valid_Payment()
    {
        // Arrange
        var totalPayment = 1000m;
        var paymentDate = new DateOnly(2023,01,31);

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
        var totalPayment = 900;
        var paymentDate = new DateOnly(2023,01,31);

        var memberId = Guid.NewGuid();
        var unionRate = 1m/10m;
        _employee.AddToUnion(memberId, unionRate);

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

        // Act
        var payroll = new MonthlyPayrollCalculator();
        var payment = _payroll.Calculate(paymentDate, _employee);
    
        // Assert
        Assert.Null(payment);
    }

    [Fact]
    public void Employee_Invalid_Employee()
    {
        // Arrange
        var paymentDate = new DateOnly(2023,01,31);

        _employee.ChangeToHourlyPayment(200);

        // Act
        var payment = () => _payroll.Calculate(paymentDate, _employee);
    
        // Assert
        Assert.Throws<InvalidOperationException>(payment);
    }
}