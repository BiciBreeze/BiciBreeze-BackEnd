using Security.Rental.Application.Commands;
using Security.Rental.Application.DTOs;
using System.Threading.Tasks;
using Security.Rental.Application.Queries;

namespace Security.Rental.Application.Interfaces
{
    public interface IRentalService
    {
        Task<int> CreateRental(CreateRentalCommand command);
        Task UpdateRentalStatus(UpdateRentalStatusCommand command);
        Task<RentalDto> GetRentalById(GetRentalByIdQuery query);
    }
}