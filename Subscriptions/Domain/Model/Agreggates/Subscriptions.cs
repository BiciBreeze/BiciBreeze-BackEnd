namespace Security.Subscriptionss.Domain.Model.Aggregates
{
    public class Subscriptions
    {
        public int Id { get; set; }
    
        public string UserId { get; set; }
    
        public string Plan { get; set; }
        
    
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int CreditCardId { get; set; }
        
    }
}