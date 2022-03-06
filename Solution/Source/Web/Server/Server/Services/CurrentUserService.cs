using CoreSharp.CleanStructure.Blazor.Server.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace CoreSharp.CleanStructure.Blazor.Server.Services
{
    internal class CurrentUserService : ICurrentUserService
    {
        //Constructors
        public CurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var currentUser = httpContextAccessor.HttpContext?.User;

            UserId = currentUser?.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            UserEmail = currentUser?.FindFirst(ClaimTypes.Upn)?.Value;
            Claims = currentUser?.Claims?.ToDictionary(c => c.Type, c => c.Value);
            Claims ??= new Dictionary<string, string>();
        }

        //Properties
        public string UserId { get; }
        public string UserEmail { get; }
        public IDictionary<string, string> Claims { get; }
    }
}
