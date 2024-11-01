namespace Security.Rent.Interfaces.REST.Resources
{
    public record OrderResource
    {
        public int Id { get; init; }
        public string BikeType { get; init; }
        public DateTime PickupDate { get; init; }
        public TimeSpan PickupTime { get; init; }
        public DateTime DropOffDate { get; init; }
        public TimeSpan DropOffTime { get; init; }
        public string PhoneNumber { get; init; }
    }
}