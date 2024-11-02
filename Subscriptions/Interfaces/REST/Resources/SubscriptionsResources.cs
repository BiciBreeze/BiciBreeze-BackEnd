using System.Runtime.InteropServices.JavaScript;

namespace Security.Subscriptionss.Interfaces.REST.Resources
{
    public record SubscriptionsResource
    {
        public SubscriptionsResource(int id, string userId , string plan, DateTime startDate, DateTime endDate)
        {
            Id = id;
            UserId  = userId ;
            Plan = plan;
            StarDate  = startDate ;
            EndDate = endDate;

        }

        public SubscriptionsResource()
        {
            throw new NotImplementedException();
        }


        public int Id { get; init; }
        public string UserId  { get; init; }
        public string Plan { get; init; }
        public DateTime StarDate { get; init; }
        public DateTime EndDate { get; init; }
    }
}