using Microsoft.AspNetCore.Authorization;

namespace Masny.Blazor.ServerSide.Authorization
{
    public class EmailRequirement : IAuthorizationRequirement
    {
        public string EmailSuffix { get; }

        public EmailRequirement(string emailSuffix)
        {
            EmailSuffix = emailSuffix;
        }
    }
}
