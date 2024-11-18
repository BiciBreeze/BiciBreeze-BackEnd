namespace Security.Rental.API.Models
{
    public class CreateRentalRequest
    {
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string BikeType { get; set; }
        public string PhoneNumber { get; set; }
        // Other relevant fields for the creation request
    }
}