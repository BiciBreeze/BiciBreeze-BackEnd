namespace Security.Rental.Application.Commands
{
    public class CreateRentalCommand
    {
        public string BikeType { get; set; }
        public DateTime PickupDateTime { get; set; }
        public DateTime DropoffDateTime { get; set; }
        public string PhoneNumber { get; set; }

        public CreateRentalCommand(string bikeType, DateTime pickupDateTime, DateTime dropoffDateTime, string phoneNumber)
        {
            BikeType = bikeType;
            PickupDateTime = pickupDateTime;
            DropoffDateTime = dropoffDateTime;
            PhoneNumber = phoneNumber;
        }
    }
}