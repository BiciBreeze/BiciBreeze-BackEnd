namespace Security.Rental.Domain.Events
{
    public class RentalOverdueEvent
    {
        public int RentalId { get; }
        public DateTime OverdueAt { get; }

        public RentalOverdueEvent(int rentalId, DateTime overdueAt)
        {
            RentalId = rentalId;
            OverdueAt = overdueAt;
        }
    }
}