using Security.IAM.Domain.Model.Commands;
using Security.IAM.Interfaces.REST.Resources;

namespace Security.IAM.Interfaces.REST.Transform;

public static class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource resource)
    {
        return new SignInCommand(resource.Username, resource.Password);
    }
}