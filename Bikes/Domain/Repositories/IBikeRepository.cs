using Security.Bikes.Domain.Model.Aggregates;


namespace Security.Bikes.Domain.Repositories
{
    public interface IBikeRepository
    {
        Task<IEnumerable<Bike>> GetAllAsync();
        Task<Bike> GetByIdAsync(int id);
        Task AddAsync(Bike bike);
        Task SaveChangesAsync();
    }
}