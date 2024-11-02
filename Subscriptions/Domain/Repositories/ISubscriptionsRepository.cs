using Security.Subscriptionss.Domain.Model.Aggregates;


namespace Security.Subscriptionss.Domain.Repositories
{
    public interface ISubscriptionsRepository
    {
        Task<IEnumerable<Subscriptions>> GetAllAsync();
        Task<Subscriptions> GetByIdAsync(int id);
        Task AddAsync(Subscriptions Subscriptions);
        Task SaveChangesAsync();
    }
}