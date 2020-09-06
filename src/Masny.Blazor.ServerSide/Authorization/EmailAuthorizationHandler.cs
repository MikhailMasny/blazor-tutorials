using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;

namespace Masny.Blazor.ServerSide.Authorization
{
    public class EmailAuthorizationHandler : AuthorizationHandler<EmailRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, EmailRequirement requirement)
        {
            if (context.User.Identity.Name.EndsWith(requirement.EmailSuffix))
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
