using Microsoft.EntityFrameworkCore;
using Security.Rental.Domain.Entities;
using Security.Rental.Domain.Interfaces;
using Security.Rental.Domain.ValueObjects;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Security.Rental.Domain.Enums;
using Security.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Security.Rental.Infrastructure.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly AppDbContext _context;

        public RentalRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(BikeRental rental)
        {
            _context.BikeRentals.Add(rental);
            await _context.SaveChangesAsync();
            return rental.Id;
        }

        public async Task<BikeRental> GetByIdAsync(int id)
        {
            return await _context.BikeRentals.FindAsync(id);
        }

        public async Task UpdateAsync(BikeRental rental)
        {
            _context.BikeRentals.Update(rental);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteRental(int id)
        {
            var rental = await _context.BikeRentals.FindAsync(id);
            if (rental != null)
            {
                _context.BikeRentals.Remove(rental);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<BikeRental>> GetActiveRentals()
        {
            return await _context.BikeRentals
                .Where(r => r.Status == RentalStatus.InProgress)
                .ToListAsync();
        }

        public async Task<IEnumerable<BikeRental>> GetRentalsByPhone(string phone)
        {
            return await _context.BikeRentals
                .Where(r => r.PhoneNumber == phone)
                .ToListAsync();
        }

        public async Task<IEnumerable<BikeRental>> GetOverdueRentals()
        {
            return await _context.BikeRentals
                .Where(r => r.Status == RentalStatus.Overdue)
                .ToListAsync();
        }

        public async Task<bool> CheckBikeAvailability(string bikeType, RentalPeriod period)
        {
            return !await _context.BikeRentals
                .AnyAsync(r => r.BikeType == bikeType &&
                               r.PickupDateTime < period.EndTime &&
                               r.DropoffDateTime > period.StartTime);
        }

        public async Task<int> GetActiveRentalsCountByPhone(string phone)
        {
            return await _context.BikeRentals
                .CountAsync(r => r.PhoneNumber == phone && r.Status == RentalStatus.InProgress);
        }

        public async Task ConfirmRental(int rentalId)
        {
            var rental = await _context.BikeRentals.FindAsync(rentalId);
            if (rental != null)
            {
                rental.ChangeStatus(RentalStatus.InProgress, "System");
                await _context.SaveChangesAsync();
            }
        }

        public async Task CancelRental(int rentalId)
        {
            var rental = await _context.BikeRentals.FindAsync(rentalId);
            if (rental != null)
            {
                rental.CancelRental();
                await _context.SaveChangesAsync();
            }
        }

        public async Task CompleteRental(int rentalId)
        {
            var rental = await _context.BikeRentals.FindAsync(rentalId);
            if (rental != null)
            {
                rental.ChangeStatus(RentalStatus.Completed, "System");
                await _context.SaveChangesAsync();
            }
        }
    }
}