// Order.cs
namespace Security.Rent.Domain.Model.Aggregates;

public abstract class Order(
    string bikeType,
    DateTime pickupDate,
    TimeSpan pickupTime,
    DateTime dropOffDate,
    TimeSpan dropOffTime,
    string phoneNumber)
{
    public int Id { get; private set; }
    public string BikeType { get; private set; } = bikeType;
    public DateTime PickupDate { get; private set; } = pickupDate;
    public TimeSpan PickupTime { get; private set; } = pickupTime;
    public DateTime DropOffDate { get; private set; } = dropOffDate;
    public TimeSpan DropOffTime { get; private set; } = dropOffTime;
    public string PhoneNumber { get; private set; } = phoneNumber;
    public int OrderNumber { get; set; } // Changed from object to int
    public int CustomerId { get; set; } // Changed from object to int

    public Order UpdateBikeType(string bikeType)
    {
        BikeType = bikeType;
        return this;
    }

    public Order UpdatePickupDate(DateTime pickupDate)
    {
        PickupDate = pickupDate;
        return this;
    }

    public Order UpdatePickupTime(TimeSpan pickupTime)
    {
        PickupTime = pickupTime;
        return this;
    }

    public Order UpdateDropOffDate(DateTime dropOffDate)
    {
        DropOffDate = dropOffDate;
        return this;
    }

    public Order UpdateDropOffTime(TimeSpan dropOffTime)
    {
        DropOffTime = dropOffTime;
        return this;
    }

    public Order UpdatePhoneNumber(string phoneNumber)
    {
        PhoneNumber = phoneNumber;
        return this;
    }
    
    public class ConcreteOrder : Order
    {
        public ConcreteOrder(string bikeType, DateTime pickupDate, TimeSpan pickupTime, DateTime dropOffDate, TimeSpan dropOffTime, string phoneNumber)
            : base(bikeType, pickupDate, pickupTime, dropOffDate, dropOffTime, phoneNumber)
        {
        }
    }
}