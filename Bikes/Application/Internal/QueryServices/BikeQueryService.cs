using Security.Bikes.Domain.Model.Aggregates;
using Security.Bikes.Domain.Repositories;

namespace Security.Bikes.Application.Internal.QueryServices
{
    public class BikeQueryService
    {
        private readonly IBikeRepository _bikeRepository;

        public BikeQueryService(IBikeRepository bikeRepository)
        {
            _bikeRepository = bikeRepository;
        }

        public async Task<IEnumerable<Bike>> GetAllBikesAsync()
        {
            return await _bikeRepository.GetAllAsync();
        }

        public async Task<Bike> GetBikeByIdAsync(int id)
        {
            return await _bikeRepository.GetByIdAsync(id);
        }
    }
}