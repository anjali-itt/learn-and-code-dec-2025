using ATMRefactoring.Controllers;
using ATMRefactoring.Exceptions;

var controller = new AtmDeviceController();

Console.WriteLine("=== ATM Withdrawal Demo ===\n");

// Successful withdrawal
try
{
    Console.WriteLine("Attempting to withdraw $200.00 from ACC-001...");
    controller.Withdraw("ACC-001", 200.00m);
    Console.WriteLine("Transaction completed successfully.\n");
}
catch (InvalidDeviceException ex)
{
    Console.WriteLine($"Device error: {ex.Message}\n");
}
catch (DeviceLockedException ex)
{
    Console.WriteLine($"Device locked: {ex.Message}\n");
}
catch (NetworkConnectionException ex)
{
    Console.WriteLine($"Network error: {ex.Message}\n");
}
catch (InsufficientFundsException ex)
{
    Console.WriteLine($"Funds error: {ex.Message}\n");
}

// Insufficient funds
try
{
    Console.WriteLine("Attempting to withdraw $10,000.00 from ACC-001...");
    controller.Withdraw("ACC-001", 10_000.00m);
    Console.WriteLine("Transaction completed successfully.\n");
}
catch (InvalidDeviceException ex)
{
    Console.WriteLine($"Device error: {ex.Message}\n");
}
catch (DeviceLockedException ex)
{
    Console.WriteLine($"Device locked: {ex.Message}\n");
}
catch (NetworkConnectionException ex)
{
    Console.WriteLine($"Network error: {ex.Message}\n");
}
catch (InsufficientFundsException ex)
{
    Console.WriteLine($"Funds error: {ex.Message}\n");
}

// Invalid account
try
{
    Console.WriteLine("Attempting to withdraw $50.00 from INVALID-ACC...");
    controller.Withdraw("INVALID-ACC", 50.00m);
    Console.WriteLine("Transaction completed successfully.\n");
}
catch (InvalidDeviceException ex)
{
    Console.WriteLine($"Device error: {ex.Message}\n");
}
catch (DeviceLockedException ex)
{
    Console.WriteLine($"Device locked: {ex.Message}\n");
}
catch (NetworkConnectionException ex)
{
    Console.WriteLine($"Network error: {ex.Message}\n");
}
catch (InsufficientFundsException ex)
{
    Console.WriteLine($"Funds error: {ex.Message}\n");
}
