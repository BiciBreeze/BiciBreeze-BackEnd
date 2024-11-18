namespace Security.Rental.Domain.Exceptions
{
    public class InvalidRentalPeriodException : Exception
    {
        public InvalidRentalPeriodException(string message) : base(message) { }
    }

    public class BikeNotAvailableException : Exception
    {
        public BikeNotAvailableException(string message) : base(message) { }
    }

    public class InvalidStatusTransitionException : Exception
    {
        public InvalidStatusTransitionException(string message) : base(message) { }
    }
}