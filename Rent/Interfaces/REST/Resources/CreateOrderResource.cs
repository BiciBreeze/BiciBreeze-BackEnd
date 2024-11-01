namespace Security.Rent.Interfaces.REST.Resources;

public record CreateOrderResource(
    string BikeType,
    DateTime PickupDate,
    TimeSpan PickupTime,
    DateTime DropOffDate,
    TimeSpan DropOffTime,
    string PhoneNumber
);