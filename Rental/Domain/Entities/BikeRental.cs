using System;
using Security.Rental.Domain.Enums;
using Security.Rental.Domain.Exceptions;

namespace Security.Rental.Domain.Entities
{
    public class BikeRental
    {
        public int Id { get; set; }
        public string BikeType { get; set; }
        public DateTime PickupDateTime { get; set; }
        public DateTime DropoffDateTime { get; set; }
        public string PhoneNumber { get; set; }
        public RentalStatus Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

        public BikeRental()
        {
            CreatedAt = DateTime.UtcNow;
            UpdatedAt = DateTime.UtcNow;
            Status = RentalStatus.Reserved;
        }

        public void ValidateDates()
        {
            if (PickupDateTime >= DropoffDateTime)
            {
                throw new InvalidRentalPeriodException("Pickup date must be before dropoff date.");
            }
            if ((PickupDateTime - DateTime.UtcNow).TotalDays > 30)
            {
                throw new InvalidRentalPeriodException("Reservations cannot be made more than 30 days in advance.");
            }
        }

        public void ValidateDuration(TimeSpan minDuration, TimeSpan maxDuration)
        {
            var duration = DropoffDateTime - PickupDateTime;
            if (duration < minDuration || duration > maxDuration)
            {
                throw new InvalidRentalPeriodException("Rental duration must be within the allowed range.");
            }
        }

        public void ChangeStatus(RentalStatus newStatus, string changedBy)
        {
            if (!IsValidStatusTransition(Status, newStatus))
            {
                throw new InvalidStatusTransitionException($"Invalid status transition from {Status} to {newStatus}.");
            }

            Status = newStatus;
            UpdatedAt = DateTime.UtcNow;
            // Log the transition with changedBy
        }

        private bool IsValidStatusTransition(RentalStatus currentStatus, RentalStatus newStatus)
        {
            return currentStatus switch
            {
                RentalStatus.Reserved => newStatus == RentalStatus.InProgress || newStatus == RentalStatus.Cancelled,
                RentalStatus.InProgress => newStatus == RentalStatus.Completed || newStatus == RentalStatus.Overdue,
                RentalStatus.Completed => false,
                RentalStatus.Cancelled => false,
                RentalStatus.Overdue => newStatus == RentalStatus.Completed,
                _ => false
            };
        }

        public decimal CalculateCost(decimal hourlyRate)
        {
            var duration = DropoffDateTime - PickupDateTime;
            return (decimal)duration.TotalHours * hourlyRate;
        }

        public decimal CalculateExtraTimeCharges(decimal extraHourlyRate)
        {
            var extraTime = DateTime.UtcNow > DropoffDateTime ? DateTime.UtcNow - DropoffDateTime : TimeSpan.Zero;
            return (decimal)extraTime.TotalHours * extraHourlyRate;
        }

        public decimal CalculateDiscount(decimal discountRate)
        {
            var duration = DropoffDateTime - PickupDateTime;
            return duration.TotalDays > 7 ? discountRate : 0;
        }

        public decimal CalculateLateReturnPenalty(decimal penaltyRate)
        {
            var lateTime = DateTime.UtcNow > DropoffDateTime ? DateTime.UtcNow - DropoffDateTime : TimeSpan.Zero;
            return (decimal)lateTime.TotalHours * penaltyRate;
        }

        public void CancelRental()
        {
            if (Status != RentalStatus.Reserved)
            {
                throw new InvalidStatusTransitionException("Only 'Reserved' rentals can be cancelled.");
            }
            if ((PickupDateTime - DateTime.UtcNow).TotalHours < 24)
            {
                throw new InvalidRentalPeriodException("Cancellations must be made at least 24 hours in advance.");
            }
            ChangeStatus(RentalStatus.Cancelled, "System");
        }

        public void CheckAndMarkOverdue()
        {
            if (Status == RentalStatus.InProgress && DateTime.UtcNow > DropoffDateTime)
            {
                ChangeStatus(RentalStatus.Overdue, "System");
            }
        }
    }
}