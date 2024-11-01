namespace Security.Rent.Domain.Model.Queries;

public class GetAllOrderByidQuery(int orderId)
{
    public int OrderId { get; } = orderId;
}

public class GetOrderByIdQuery(int orderId)
{
    public int OrderId { get; } = orderId;
}