namespace Security.Rental.Domain.Events
{
    public class RentalCreatedEvent
    {
        public int RentalId { get; }
        public DateTime CreatedAt { get; }

        public RentalCreatedEvent(int rentalId, DateTime createdAt)
        {
            RentalId = rentalId;
            CreatedAt = createdAt;
        }
    }
}