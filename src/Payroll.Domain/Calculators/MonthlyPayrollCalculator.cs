namespace Payroll.Domain.Calculators;

public class MonthlyPayrollCalculator
{
    public Payment? Calculate(DateOnly paymentDate, Employee employee)
    {
        if (!LastBusinessDay(paymentDate).Equals(paymentDate))
            return default;
        
        if (employee.PaymentType != PaymentType.Monthly)
            throw new InvalidOperationException("This employee has a payment type different then Monthly.");
            
        decimal paymentValue = employee.PaymentValue;

        if (employee.IsUnionized)
        {
            var dueSum = employee.ServiceCharges.Sum(s => s.Due);
            paymentValue -= dueSum + employee.UnionDueRate * (paymentValue - dueSum);
        }

        return new Payment(paymentDate, paymentValue);
    }

    private DateOnly LastBusinessDay(DateOnly currentMonth)
    {
        return
            DateOnly.FromDateTime(Enumerable.Range(1, DateTime.DaysInMonth(currentMonth.Year, currentMonth.Month))
                .Select(day => new DateTime(currentMonth.Year, currentMonth.Month, day))
                .Where(
                    dt =>
                    dt.DayOfWeek != DayOfWeek.Sunday && dt.DayOfWeek != DayOfWeek.Saturday)
                .Max(d => d.Date));
    }
}