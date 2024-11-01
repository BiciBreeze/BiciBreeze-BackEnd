using Security.Rent.Domain.Model.Aggregates;

namespace Security.Rent.Domain.Model.Commands;


public class CreateOrderCommand
{
    public string BikeType { get; }
    public DateTime PickupDate { get; }
    public TimeSpan PickupTime { get; }
    public DateTime DropOffDate { get; }
    public TimeSpan DropOffTime { get; }
    public string PhoneNumber { get; }
    public object OrderId { get; }

    public CreateOrderCommand(string bikeType, DateTime pickupDate, TimeSpan pickupTime, DateTime dropOffDate, TimeSpan dropOffTime, string phoneNumber)
    {
        BikeType = bikeType;
        PickupDate = pickupDate;
        PickupTime = pickupTime;
        DropOffDate = dropOffDate;
        DropOffTime = dropOffTime;
        PhoneNumber = phoneNumber;
    }
}

public class GetOrderByIdCommand
{
    public int OrderId { get; }

    public GetOrderByIdCommand(int orderId)
    {
        OrderId = orderId;
    }
    
    public interface IOrderCommandService
    {
        Task Handle(CreateOrderCommand command);
        Task<Order?> Handle(GetOrderByIdCommand command);
    }
}