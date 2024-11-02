using Security.Subscriptionss.Domain.Model.Aggregates;
using Security.Subscriptionss.Domain.Repositories;

namespace Security.Subscriptionss.Application.Internal.CommandServices
{
    public class ISubscriptionsCommandService
    {
        private readonly ISubscriptionsRepository _SubscriptionsRepository;

        public ISubscriptionsCommandService(ISubscriptionsRepository SubscriptionsRepository)
        {
            _SubscriptionsRepository = SubscriptionsRepository;
        }

        public async Task AddSubscriptionsAsync(Subscriptions Subscriptions)
        {
            await _SubscriptionsRepository.AddAsync(Subscriptions);
            await _SubscriptionsRepository.SaveChangesAsync();
        }
    }
}