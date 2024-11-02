using Security.Bikes.Domain.Model.Aggregates;
using Security.Bikes.Domain.Repositories;

namespace Security.Bikes.Application.Internal.CommandServices
{
    public class BikeCommandService
    {
        private readonly IBikeRepository _bikeRepository;

        public BikeCommandService(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public async Task AddBikeAsync(Bike bike)
        {
            await _bikeRepository.AddAsync(bike);
            await _bikeRepository.SaveChangesAsync();
        }
    }
}