using Security.IAM.Domain.Model.Aggregates;
using Security.Shared.Domain.Repositories;

namespace Security.IAM.Domain.Repositories;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User?> FindByUsernameAsync(string username);
    bool ExistsByUsername(string username);
}