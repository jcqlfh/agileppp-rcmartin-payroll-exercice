using Xunit;
using Payroll.Domain;
using Payroll.Domain.Calculators;

namespace Payroll.Tests.Domain.Calculators;

public class CommissionedPayrollCalculatorTests
{
    private Employee _employee;

    private CommissionedPayrollCalculator _payroll;

    public CommissionedPayrollCalculatorTests()
    {
        _employee = new Employee(
            "Name",
            "Address",
            PaymentType.Commissioned,
            1000m,
            0.1m
        );

        _payroll = new CommissionedPayrollCalculator();
    }

    [Fact]
    public void Employee_Valid_Payment()
    {
        // Arrange
        var totalPayment = 1100m;
        var paymentDate = new DateOnly(2023,01,31);

        _employee.AddSalesReceipt(paymentDate, 1000m);
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
        var payroll = new CommissionedPayrollCalculator();
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