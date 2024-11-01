namespace Security.Rent.Domain.Model.Commands;

public class UpdateOrderCommand(
    int orderId,
    string bikeType,
    DateTime pickupDate,
    TimeSpan pickupTime,
    DateTime dropOffDate,
    TimeSpan dropOffTime,
    string phoneNumber)
{
    public int OrderId { get; } = orderId;
    public string BikeType { get; } = bikeType;
    public DateTime PickupDate { get; } = pickupDate;
    public TimeSpan PickupTime { get; } = pickupTime;
    public DateTime DropOffDate { get; } = dropOffDate;
    public TimeSpan DropOffTime { get; } = dropOffTime;
    public string PhoneNumber { get; } = phoneNumber;
}