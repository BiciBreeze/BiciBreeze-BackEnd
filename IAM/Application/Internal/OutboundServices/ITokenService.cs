using Security.IAM.Domain.Model.Aggregates;

namespace Security.IAM.Application.Internal.OutboundServices;

public interface ITokenService
{
    string GenerateToken(User user);
    Task<int?> ValidateToken(string token);
}