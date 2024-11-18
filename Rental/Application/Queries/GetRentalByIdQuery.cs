namespace Security.Rental.Application.Queries
{
    public class GetRentalByIdQuery
    {
        public int RentalId { get; set; }

        public GetRentalByIdQuery(int rentalId)
        {
            RentalId = rentalId;
        }
    }
}