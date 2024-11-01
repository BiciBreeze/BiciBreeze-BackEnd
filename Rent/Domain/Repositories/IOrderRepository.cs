using Security.Rent.Domain.Model.Aggregates;
using Security.Shared.Domain.Repositories;

namespace Security.Rent.Domain.Repositories;

public interface IOrderRepository : IBaseRepository<Order>
{
    new Task<Order?> FindByIdAsync(int orderId);
    bool ExistsById(int orderId);
    Task<IEnumerable<Order>> GetAllAsync();
}