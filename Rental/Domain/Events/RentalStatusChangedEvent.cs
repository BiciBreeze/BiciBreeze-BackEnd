using Security.Rental.Domain.Enums;

namespace Security.Rental.Domain.Events
{
    public class RentalStatusChangedEvent
    {
        public int RentalId { get; }
        public RentalStatus OldStatus { get; }
        public RentalStatus NewStatus { get; }
        public DateTime ChangedAt { get; }

        public RentalStatusChangedEvent(int rentalId, RentalStatus oldStatus, RentalStatus newStatus, DateTime changedAt)
        {
            RentalId = rentalId;
            OldStatus = oldStatus;
            NewStatus = newStatus;
            ChangedAt = changedAt;
        }
    }
}