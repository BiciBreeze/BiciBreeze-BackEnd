using Security.Rental.Domain.Enums;

namespace Security.Rental.Application.Commands
{
    public class UpdateRentalStatusCommand
    {
        public int RentalId { get; set; }
        public RentalStatus NewStatus { get; set; }

        public UpdateRentalStatusCommand(int rentalId, RentalStatus newStatus)
        {
            RentalId = rentalId;
            NewStatus = newStatus;
        }
    }
}