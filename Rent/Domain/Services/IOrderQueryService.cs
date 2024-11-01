using Security.Rent.Domain.Model.Aggregates;
using Security.Rent.Domain.Model.Queries;

namespace Security.Rent.Domain.Services;

public interface IOrderQueryService
{
    Task<IEnumerable<Order>> Handle(GetAllOrdersQuery query);
    Task<Order?> Handle(GetOrderByIdQuery query);
    
}