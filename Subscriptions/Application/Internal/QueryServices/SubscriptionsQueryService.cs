using Security.Subscriptionss.Domain.Model.Aggregates;
using Security.Subscriptionss.Domain.Repositories;

namespace Security.Subscriptionss.Application.Internal.QueryServices
{
    public class SubscriptionsQueryService
    {
        private readonly ISubscriptionsRepository _SubscriptionsRepository;

        public SubscriptionsQueryService(ISubscriptionsRepository SubscriptionsRepository)
        {
            _SubscriptionsRepository = SubscriptionsRepository;
        }

        public async Task<IEnumerable<Subscriptions>> GetAllSubscriptionssAsync()
        {
            return await _SubscriptionsRepository.GetAllAsync();
        }

        public async Task<Subscriptions> GetSubscriptionsByIdAsync(int id)
        {
            return await _SubscriptionsRepository.GetByIdAsync(id);
        }
    }
}