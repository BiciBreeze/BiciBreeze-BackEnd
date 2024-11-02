using Security.Subscriptionss.Domain.Model.Aggregates;
using Security.Subscriptionss.Domain.Repositories;

namespace Security.Subscriptionss.Infrastructure.Repositories
{
    public class SubscriptionsRepository : ISubscriptionsRepository
    {
        private readonly List<Subscriptions> _Subscriptionss = new List<Subscriptions>();

        public async Task<IEnumerable<Subscriptions>> GetAllAsync()
        {
            return await Task.FromResult(_Subscriptionss);
        }

        public async Task<Subscriptions> GetByIdAsync(int id)
        {
            var Subscriptions = _Subscriptionss.FirstOrDefault(b => b.Id == id);
            return await Task.FromResult(Subscriptions);
        }

        public async Task AddAsync(Subscriptions Subscriptions)
        {
            _Subscriptionss.Add(Subscriptions);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            // In a real implementation, this would save changes to the database
            await Task.CompletedTask;
        }
    }
}