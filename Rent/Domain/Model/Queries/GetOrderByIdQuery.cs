namespace Security.Rent.Domain.Model.Queries
{
    public class GetOrderByIdQuery
    {
        public GetOrderByIdQuery(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; init; }
    }
}