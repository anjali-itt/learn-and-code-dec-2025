namespace ATMRefactoring.Models;

public enum DeviceStatus
{
    Active,
    Suspended
}

public enum WifiConnection
{
    Connected,
    Disconnected
}

public class DeviceRecord
{
    public DeviceStatus Status { get; set; }
    public WifiConnection WifiConnection { get; set; }
    public decimal Balance { get; set; }
}
