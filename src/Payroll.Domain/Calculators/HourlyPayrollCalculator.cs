namespace Payroll.Domain.Calculators;

public class HourlyPayrollCalculator
{
    private const DayOfWeek PAYMENT_WEEK_DAY = DayOfWeek.Friday;

    public Payment? Calculate(DateOnly paymentDate, Employee employee)
    {
        if (!paymentDate.DayOfWeek.Equals(PAYMENT_WEEK_DAY))
            return default;
        
        if (employee.PaymentType != PaymentType.Hourly)
            throw new InvalidOperationException("This employee has a payment type different then hourly.");
            
        var lastPaymentDate = LastPaymentDate(paymentDate, paymentDate);

        var hoursLogged = employee.TimeCards.Where(t => t.Date >= lastPaymentDate && t.Date <= paymentDate);

        decimal paymentValue = 0m;
        decimal hours = 0;
        foreach(var timeCard in hoursLogged)
        {
            if(timeCard.HoursWorked > 8m)
                hours += 8m + (timeCard.HoursWorked - 8m) * 1.5m;
            else
                hours += timeCard.HoursWorked;

            paymentValue += hours * employee.PaymentValue;
            hours = 0m;
        }

        if (employee.IsUnionized)
        {
            var dueSum = employee.ServiceCharges.Sum(s => s.Due);
            paymentValue -= dueSum + employee.UnionDueRate * (paymentValue - dueSum);
        }

        return new Payment(paymentDate, paymentValue);
    }

    private DateOnly LastPaymentDate(DateOnly paymentDate, DateOnly lastPaymentDate)
    {
        if (paymentDate.Equals(lastPaymentDate))
            return LastPaymentDate(paymentDate, lastPaymentDate.AddDays(-1));

        if (!lastPaymentDate.DayOfWeek.Equals(PAYMENT_WEEK_DAY))
            return LastPaymentDate(paymentDate, lastPaymentDate.AddDays(-1));

        return lastPaymentDate;
    }
}