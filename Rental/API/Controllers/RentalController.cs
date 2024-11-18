using Microsoft.AspNetCore.Mvc;
using Security.Rental.Domain.Entities;
using Security.Rental.Domain.Enums;
using Security.Rental.Domain.Interfaces;
using System;
using System.Threading.Tasks;

namespace Security.Rental.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase
    {
        private readonly IRentalRepository _rentalRepository;

        public RentalController(IRentalRepository rentalRepository)
        {
            _rentalRepository = rentalRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRental([FromBody] BikeRental rental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            rental.Status = RentalStatus.Reserved;
            rental.CreatedAt = DateTime.UtcNow;
            rental.UpdatedAt = DateTime.UtcNow;

            try
            {
                rental.ValidateDates();
                await _rentalRepository.AddAsync(rental);
                return CreatedAtAction(nameof(GetRentalById), new { id = rental.Id }, rental);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalById(int id)
        {
            var rental = await _rentalRepository.GetByIdAsync(id);
            if (rental == null)
            {
                return NotFound();
            }

            return Ok(rental);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRental(int id, [FromBody] BikeRental updatedRental)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rental = await _rentalRepository.GetByIdAsync(id);
            if (rental == null)
            {
                return NotFound();
            }

            rental.BikeType = updatedRental.BikeType;
            rental.PickupDateTime = updatedRental.PickupDateTime;
            rental.DropoffDateTime = updatedRental.DropoffDateTime.Date;
            rental.PhoneNumber = updatedRental.PhoneNumber;
            rental.Status = updatedRental.Status;
            rental.UpdatedAt = DateTime.UtcNow;

            try
            {
                rental.ValidateDates();
                await _rentalRepository.UpdateAsync(rental);
                return Ok(rental);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}