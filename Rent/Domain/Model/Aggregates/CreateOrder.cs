namespace Security.Rent.Domain.Model.Aggregates;

public class ConcreteOrder : Order
{
    public ConcreteOrder(string bikeType, DateTime pickupDate, TimeSpan pickupTime, DateTime dropOffDate, TimeSpan dropOffTime, string phoneNumber)
        : base(bikeType, pickupDate, pickupTime, dropOffDate, dropOffTime, phoneNumber)
    {
    }
}