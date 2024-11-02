using Security.Bikes.Domain.Model.Aggregates;
using Security.Bikes.Domain.Repositories;

namespace Security.Bikes.Infrastructure.Repositories
{
    public class BikeRepository : IBikeRepository
    {
        private readonly List<Bike> _bikes = new List<Bike>();

        public async Task<IEnumerable<Bike>> GetAllAsync()
        {
            return await Task.FromResult(_bikes);
        }

        public async Task<Bike> GetByIdAsync(int id)
        {
            var bike = _bikes.FirstOrDefault(b => b.Id == id);
            return await Task.FromResult(bike);
        }

        public async Task AddAsync(Bike bike)
        {
            _bikes.Add(bike);
            await Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            // In a real implementation, this would save changes to the database
            await Task.CompletedTask;
        }
    }
}