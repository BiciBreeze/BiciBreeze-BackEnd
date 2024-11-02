namespace Security.Subscriptionss.Domain.Model.Commands
{
    public class AddSubscriptionsCommand
    {
        public string Type { get; set; }
        public bool IsAvailable { get; set; }
    }
}