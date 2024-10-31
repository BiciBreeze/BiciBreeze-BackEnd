using Security.Shared.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Security.IAM.Domain.Model.Aggregates;
using Security.IAM.Domain.Repositories;
using Security.Shared.Infrastructure.Persistence.EFC.Configuration;
using Security.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Security.IAM.Infrastructure.Persistence.EFC.Repositories;

public class UserRepository(AppDbContext context) : BaseRepository<User>(context), IUserRepository 
{
    public async Task<User?> FindByUsernameAsync(string username)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Username.Equals(username));
    }

    public bool ExistsByUsername(string username)
    {
        return Context.Set<User>().Any(user => user.Username.Equals(username));
    }
}