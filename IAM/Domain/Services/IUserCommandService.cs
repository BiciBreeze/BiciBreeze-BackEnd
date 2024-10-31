using Security.IAM.Domain.Model.Aggregates;
using Security.IAM.Domain.Model.Commands;

namespace Security.IAM.Domain.Services;

public interface IUserCommandService
{
    Task Handle(SignUpCommand command);
    Task<(User user, string token)> Handle(SignInCommand command);
}