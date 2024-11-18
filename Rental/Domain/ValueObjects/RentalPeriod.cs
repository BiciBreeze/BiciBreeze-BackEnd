using System;
using Security.Rental.Domain.Exceptions;

namespace Security.Rental.Domain.ValueObjects
{
    public class RentalPeriod
    {
        public DateTime StartTime { get; private set; }
        public DateTime EndTime { get; private set; }
        public TimeSpan Duration => EndTime - StartTime;

        private static readonly TimeSpan MinDuration = TimeSpan.FromHours(1);
        private static readonly TimeSpan MaxDuration = TimeSpan.FromHours(72);
        private static readonly TimeSpan OpeningTime = new TimeSpan(9, 0, 0); // 9 AM
        private static readonly TimeSpan ClosingTime = new TimeSpan(21, 0, 0); // 9 PM

        public RentalPeriod(DateTime startTime, DateTime endTime)
        {
            StartTime = startTime;
            EndTime = endTime;

            Validate();
        }

        private void Validate()
        {
            ValidateBusinessHours();
            ValidateDuration();
            ValidateAllowedDays();
            ValidateMaintenancePeriods();
        }

        private void ValidateBusinessHours()
        {
            if (StartTime.TimeOfDay < OpeningTime || EndTime.TimeOfDay > ClosingTime)
            {
                throw new InvalidRentalPeriodException("Rental period must be within business hours (9 AM - 9 PM).");
            }
        }

        private void ValidateDuration()
        {
            if (Duration < MinDuration || Duration > MaxDuration)
            {
                throw new InvalidRentalPeriodException("Rental duration must be between 1 hour and 72 hours.");
            }
        }

        private void ValidateAllowedDays()
        {
            // Implement logic to validate allowed days if necessary
        }

        private void ValidateMaintenancePeriods()
        {
            // Implement logic to validate against maintenance periods if necessary
        }

        public bool OverlapsWith(RentalPeriod other)
        {
            return StartTime < other.EndTime && EndTime > other.StartTime;
        }
    }
}