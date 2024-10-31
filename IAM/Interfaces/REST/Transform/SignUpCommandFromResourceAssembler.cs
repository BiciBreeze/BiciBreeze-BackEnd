using Security.IAM.Domain.Model.Commands;
using Security.IAM.Interfaces.REST.Resources;

namespace Security.IAM.Interfaces.REST.Transform;

public static class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(resource.Username, resource.Password);
    }

}