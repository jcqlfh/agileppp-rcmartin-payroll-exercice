using Xunit;
using Payroll.Domain;

namespace Payroll.Tests.Domain;

public class PaycheckSettingsTests
{
    [Fact]
    public void New_PaycheckSettings_With_Valid_Mail()
    {
        // Arrange
        var newPaymentMethod = PaymentMethod.Mail;
        var newMethodAddress = "Address";

        // Act
        var paycheck = new PaycheckSettings(newPaymentMethod, newMethodAddress);

        // Assert
        Assert.Equal(newPaymentMethod, paycheck.Method);
        Assert.Equal(newMethodAddress, paycheck.Address);
        Assert.Null(paycheck.Bank);
        Assert.Null(paycheck.BankAccount);
    }

    [Fact]
    public void New_PaycheckSettings_With_Invalid_Mail()
    {
        // Arrange
        var newPaymentMethod = PaymentMethod.Mail;
        var newMethodAddress = "";

        // Act
        var paycheck = () => new PaycheckSettings(newPaymentMethod, newMethodAddress);

        // Assert
        Assert.Throws<ArgumentNullException>(paycheck);
    }

    [Fact]
    public void New_PaycheckSettings_With_Valid_Direct()
    {
        // Arrange
        var newPaymentMethod = PaymentMethod.Direct;
        var newMethodBank = "Bank";
        var newMethodBankAccount = "BankAccount";

        // Act
        var paycheck = new PaycheckSettings(newPaymentMethod, null, newMethodBank, newMethodBankAccount);

        // Assert
        Assert.Equal(newPaymentMethod, paycheck.Method);
        Assert.Null(paycheck.Address);
        Assert.Equal(newMethodBank, paycheck.Bank);
        Assert.Equal(newMethodBankAccount, paycheck.BankAccount);
    }

    [Fact]
    public void New_PaycheckSettings_With_Invalid_Direct_Bank()
    {
        // Arrange
        var newPaymentMethod = PaymentMethod.Direct;
        var newMethodBank = "";
        var newMethodBankAccount = "BankAccount";

        // Act
        var paycheck = () => new PaycheckSettings(newPaymentMethod, null, newMethodBank, newMethodBankAccount);

        // Assert
        Assert.Throws<ArgumentNullException>(paycheck);
    }

    [Fact]
    public void New_PaycheckSettings_With_Invalid_Direct_BankAccount()
    {
        // Arrange
        var newPaymentMethod = PaymentMethod.Direct;
        var newMethodBank = "Bank";
        var newMethodBankAccount = "";

        // Act
        var paycheck = () => new PaycheckSettings(newPaymentMethod, null, newMethodBank, newMethodBankAccount);

        // Assert
        Assert.Throws<ArgumentNullException>(paycheck);
    }

    [Fact]
    public void New_PaycheckSettings_With_Valid_Hold()
    {
        // Arrange
        var newPaymentMethod = PaymentMethod.Hold;

        // Act
        var paycheck = new PaycheckSettings(newPaymentMethod);

        // Assert
        Assert.Equal(newPaymentMethod, paycheck.Method);
        Assert.Null(paycheck.Address);
        Assert.Null(paycheck.Bank);
        Assert.Null(paycheck.BankAccount);
    }
}