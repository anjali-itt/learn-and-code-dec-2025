namespace ATMRefactoring.Exceptions;

public class DeviceLockedException : Exception
{
    public DeviceLockedException()
        : base("Device is suspended and cannot process transactions.") { }

    public DeviceLockedException(string message)
        : base(message) { }

    public DeviceLockedException(string message, Exception innerException)
        : base(message, innerException) { }
}
