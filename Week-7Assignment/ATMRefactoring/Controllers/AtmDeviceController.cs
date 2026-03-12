using ATMRefactoring.Exceptions;
using ATMRefactoring.Models;

namespace ATMRefactoring.Controllers;

public class AtmDeviceController
{
    private readonly DeviceHandle device;
    private readonly Dictionary<string, DeviceRecord> accounts;

    public AtmDeviceController()
    {
        device = new DeviceHandle(1);
        accounts = new Dictionary<string, DeviceRecord>
        {
            ["ACC-001"] = new DeviceRecord
            {
                Status = DeviceStatus.Active,
                WifiConnection = WifiConnection.Connected,
                Balance = 5000.00m
            }
        };
    }

    public void Withdraw(string accountId, decimal amount)
    {
        DeviceHandle handle = GetHandle();
        ValidateDevice(handle);
        ValidateConnection(accountId);
        ValidateBalance(accountId, amount);
        DispenseCash(accountId, amount);
    }

    private DeviceHandle GetHandle()
    {
        return device;
    }

    private void ValidateDevice(DeviceHandle handle)
    {
        if (handle.IsInvalid)
            throw new InvalidDeviceException();
    }

    private void ValidateConnection(string accountId)
    {
        var record = GetRecord(accountId);

        if (record.Status == DeviceStatus.Suspended)
            throw new DeviceLockedException();

        if (record.WifiConnection == WifiConnection.Disconnected)
            throw new NetworkConnectionException();
    }

    private void ValidateBalance(string accountId, decimal amount)
    {
        var record = GetRecord(accountId);

        if (record.Balance < amount)
            throw new InsufficientFundsException(
                $"Requested {amount:C} but only {record.Balance:C} available.");
    }

    private void DispenseCash(string accountId, decimal amount)
    {
        var record = GetRecord(accountId);
        record.Balance -= amount;
        Console.WriteLine($"Dispensed {amount:C}. Remaining balance: {record.Balance:C}");
    }

    private DeviceRecord GetRecord(string accountId)
    {
        if (!accounts.TryGetValue(accountId, out var record))
            throw new InvalidDeviceException($"Account '{accountId}' not found.");

        return record;
    }
}
