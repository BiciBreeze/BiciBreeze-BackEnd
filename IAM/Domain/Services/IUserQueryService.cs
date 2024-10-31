using Security.IAM.Domain.Model.Aggregates;
using Security.IAM.Domain.Model.Queries;

namespace Security.IAM.Domain.Services;

public interface IUserQueryService
{
    Task<IEnumerable<User>> Handle(GetAllUsersQuery query);
    Task<User?> Handle(GetUserByIdQuery query);
    Task<User?> Handle(GetUserByUsernameQuery query);
}