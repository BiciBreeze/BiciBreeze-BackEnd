using Security.Rental.Application.Commands;
using Security.Rental.Application.DTOs;
using Security.Rental.Application.Interfaces;
using Security.Rental.Application.Queries;
using Security.Rental.Domain.Entities;
using Security.Rental.Domain.Interfaces;
using System;
using System.Threading.Tasks;
using Security.Rental.Domain.Enums;

namespace Security.Rental.Application.Services
{
    public class RentalService : IRentalService
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalService(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        public async Task<int> CreateRental(CreateRentalCommand command)
        {
            // Validate the command data
            // Map the command to a domain entity
            var rental = new BikeRental
            {
                BikeType = command.BikeType,
                PickupDateTime = command.PickupDateTime,
                DropoffDateTime = command.DropoffDateTime,
                PhoneNumber = command.PhoneNumber,
                Status = RentalStatus.Reserved,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            // Save the rental using the repository
            var rentalId = await _rentalRepository.AddAsync(rental);
            return rentalId;
        }

        public async Task UpdateRentalStatus(UpdateRentalStatusCommand command)
        {
            // Retrieve the rental from the repository
            var rental = await _rentalRepository.GetByIdAsync(command.RentalId);
            if (rental == null)
            {
                throw new Exception("Rental not found");
            }

            // Update the rental status
            rental.ChangeStatus(command.NewStatus, "User");
            rental.UpdatedAt = DateTime.UtcNow;

            // Save the changes using the repository
            await _rentalRepository.UpdateAsync(rental);
        }

        public async Task<RentalDto> GetRentalById(GetRentalByIdQuery query)
        {
            // Retrieve the rental from the repository
            var rental = await _rentalRepository.GetByIdAsync(query.RentalId);
            if (rental == null)
            {
                throw new Exception("Rental not found");
            }

            // Map the domain entity to a DTO
            var rentalDto = new RentalDto
            {
                Id = rental.Id,
                BikeType = rental.BikeType,
                PickupDateTime = rental.PickupDateTime,
                DropoffDateTime = rental.DropoffDateTime,
                PhoneNumber = rental.PhoneNumber,
                Status = rental.Status.ToString(),
                CreatedAt = rental.CreatedAt,
                UpdatedAt = rental.UpdatedAt
            };

            return rentalDto;
        }
    }
}