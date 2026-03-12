namespace ATMRefactoring.Models;

public class DeviceHandle
{
    public static readonly DeviceHandle Invalid = new(-1);

    public int Id { get; }

    public DeviceHandle(int id)
    {
        Id = id;
    }

    public bool IsInvalid => Id == Invalid.Id;
}
