namespace ATMRefactoring.Exceptions;

public class NetworkConnectionException : Exception
{
    public NetworkConnectionException()
        : base("Network connection is unavailable.") { }

    public NetworkConnectionException(string message)
        : base(message) { }

    public NetworkConnectionException(string message, Exception innerException)
        : base(message, innerException) { }
}
