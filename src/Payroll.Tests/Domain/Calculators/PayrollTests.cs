using Xunit;
using Payroll.Domain;
using Payroll.Domain.Calculators;

namespace Payroll.Tests.Domain.Calculators;

public class HourlyPayrollCalculatorTests
{
    public void Calculate_Hourly_Payroll()
    {
        var payRoll = new PayrollCalculator();

        var date = DateOnly.FromDateTime(DateTime.Now);
        
        IList<Payment> result = payRoll.Calculate(date);

    }
}