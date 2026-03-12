namespace ATMRefactoring.Exceptions;

public class InsufficientFundsException : Exception
{
    public InsufficientFundsException()
        : base("Insufficient funds for this withdrawal.") { }

    public InsufficientFundsException(string message)
        : base(message) { }

    public InsufficientFundsException(string message, Exception innerException)
        : base(message, innerException) { }
}
