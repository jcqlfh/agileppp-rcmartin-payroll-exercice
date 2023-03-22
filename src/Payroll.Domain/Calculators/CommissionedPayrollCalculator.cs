namespace Payroll.Domain.Calculators;

public class CommissionedPayrollCalculator
{
    public Payment? Calculate(DateOnly paymentDate, Employee employee)
    {
        if (!LastBusinessDay(paymentDate).Equals(paymentDate))
            return default;
        
        if (employee.PaymentType != PaymentType.Commissioned)
            throw new InvalidOperationException("This employee has a payment type different then Commissioned.");
            
        var lastPaymentDate = LastBusinessDay(paymentDate.AddMonths(-1));

        decimal paymentValue = employee.PaymentValue;

        paymentValue += employee.SalesReceipts
            .Where(s => s.Date > lastPaymentDate && s.Date <= paymentDate)
            .Sum(s => s.Amount*employee.Rate);

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