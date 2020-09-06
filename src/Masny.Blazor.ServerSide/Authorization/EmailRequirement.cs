using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
