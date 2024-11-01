namespace Security.Rent.Interfaces.REST.Resources;

public record UpdateOrderResource(
    string BikeType,
    DateTime PickupDate,
    TimeSpan PickupTime,
    DateTime DropOffDate,
    TimeSpan DropOffTime,
    string PhoneNumber
);