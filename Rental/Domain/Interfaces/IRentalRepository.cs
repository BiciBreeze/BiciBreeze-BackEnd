using Security.Rental.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using Security.Rental.Domain.ValueObjects;

namespace Security.Rental.Domain.Interfaces
{
    public interface IRentalRepository
    {
        Task<int> AddAsync(BikeRental rental);
        Task<BikeRental> GetByIdAsync(int id);
        Task UpdateAsync(BikeRental rental);
        Task DeleteRental(int id);

        Task<IEnumerable<BikeRental>> GetActiveRentals();
        Task<IEnumerable<BikeRental>> GetRentalsByPhone(string phone);
        Task<IEnumerable<BikeRental>> GetOverdueRentals();
        Task<bool> CheckBikeAvailability(string bikeType, RentalPeriod period);
        Task<int> GetActiveRentalsCountByPhone(string phone);

        Task ConfirmRental(int rentalId);
        Task CancelRental(int rentalId);
        Task CompleteRental(int rentalId);
    }
}