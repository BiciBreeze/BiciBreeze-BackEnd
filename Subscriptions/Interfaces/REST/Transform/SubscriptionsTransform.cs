using Security.Subscriptionss.Domain.Model.Aggregates;
using Security.Subscriptionss.Interfaces.REST.Resources;

namespace Security.Subscriptionss.Interfaces.REST.Transform
{
    public static class SubscriptionsTransform
    {
        public static SubscriptionsResource ToResource(Subscriptions entity)
        {
            return new SubscriptionsResource
            {
                Id = entity.Id,
                UserId  = entity.UserId ,
                Plan = entity.Plan,
                StarDate  = entity.StartDate,
                EndDate = entity.EndDate
            };
        }
        public static Subscriptions ToEntity(SubscriptionsResource resource)
        {
            return new Subscriptions
            {
                Id = resource.Id,
                UserId = resource.UserId,
                Plan = resource.Plan,
                StartDate = resource.StarDate,
                EndDate = resource.EndDate
            };
        }
    }
}