using CoreSharp.DependencyInjection.Interfaces;
using CoreSharp.Extensions;
using CoreSharp.Templates.Blazor.Server.Application.Services.Contracts;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;

namespace CoreSharp.Templates.Blazor.Server.Infrastructure.Services
{
    public class ServerCurrentUserService : IServerCurrentUserService, IScoped<IServerCurrentUserService>
    {
        //Constructors
        public ServerCurrentUserService(IHttpContextAccessor httpContextAccessor)
        {
            var claimsPrincipal = httpContextAccessor?.HttpContext?.User;

            //Extract information 
            IsAuthenticated = GetIsAuthenticated(claimsPrincipal);
            Id = GetId(claimsPrincipal);
            Name = GetName(claimsPrincipal);
            Email = GetEmail(claimsPrincipal);
            Claims = GetClaims(claimsPrincipal);
        }

        //Properties
        public bool IsAuthenticated { get; }
        public string Id { get; }
        public string Name { get; }
        public string Email { get; }
        public IReadOnlyDictionary<string, string> Claims { get; } = ImmutableDictionary<string, string>.Empty;

        //Methods 
        private static bool GetIsAuthenticated(ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal?.Identity?.IsAuthenticated is true;

        private static string GetId(ClaimsPrincipal claimsPrincipal)
            => GetClaimValue(claimsPrincipal, ClaimTypes.NameIdentifier);

        private static string GetName(ClaimsPrincipal claimsPrincipal)
            => GetClaimValue(claimsPrincipal, "nickname");

        private static string GetEmail(ClaimsPrincipal claimsPrincipal)
            => GetClaimValue(claimsPrincipal, ClaimTypes.Email);

        private static string GetClaimValue(ClaimsPrincipal claimsPrincipal, string claimType)
            => claimsPrincipal?.FindFirst(claimType)?.Value;

        private static IReadOnlyDictionary<string, string> GetClaims(ClaimsPrincipal claimsPrincipal)
        {
            var dictionary = claimsPrincipal?.Claims?.ToDictionary(c => c.Type, c => c.Value);
            return new ReadOnlyDictionary<string, string>(dictionary);
        }
    }
}