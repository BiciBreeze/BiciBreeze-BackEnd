using Security.IAM.Domain.Model.Aggregates;
using Security.IAM.Interfaces.REST.Resources;

namespace Security.IAM.Interfaces.REST.Transform;

public static class UserResourceFromEntityAssembler
{
    public static UserResource ToResourceFromEntity(User entity)
    {
        return new UserResource(entity.Id, entity.Username);
    }
}