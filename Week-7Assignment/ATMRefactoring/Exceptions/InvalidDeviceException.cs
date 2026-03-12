namespace ATMRefactoring.Exceptions;

public class InvalidDeviceException : Exception
{
    public InvalidDeviceException()
        : base("Device handle is invalid.") { }

    public InvalidDeviceException(string message)
        : base(message) { }

    public InvalidDeviceException(string message, Exception innerException)
        : base(message, innerException) { }
}
