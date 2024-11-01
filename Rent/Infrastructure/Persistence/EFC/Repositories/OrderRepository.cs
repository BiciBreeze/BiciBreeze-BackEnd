using Security.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Security.Rent.Domain.Model.Aggregates;
using Security.Rent.Domain.Repositories;
using Security.Shared.Infrastructure.Persistence.EFC.Configuration;
using Security.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Security.Rent.Infrastructure.Persistence.EFC.Repositories;

public class OrderRepository : BaseRepository<Order>, IOrderRepository
{
    public OrderRepository(AppDbContext context) : base(context)
    {
    }

    public async Task<Order?> FindByIdAsync(int orderId)
    {
        return await Context.Set<Order>().FirstOrDefaultAsync(order => order.Id == orderId);
    }

    public async Task<IEnumerable<Order>> GetAllAsync()
    {
        return await Context.Set<Order>().ToListAsync();
    }

    public bool ExistsById(int orderId)
    {
        return Context.Set<Order>().Any(order => order.Id == orderId);
    }
}