using CoreSharp.Delegates;
using CoreSharp.DependencyInjection.Interfaces;
using CoreSharp.Extensions;
using CoreSharp.Templates.Blazor.Server.Application.Services.Contracts;
using Microsoft.AspNetCore.Components.Authorization;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CoreSharp.Templates.Blazor.Server.Infrastructure.Services
{
    public class CurrentUserService : ICurrentUserService, IScoped<ICurrentUserService>
    {
        //Fields
        private readonly AuthenticationStateProvider _authenticationStateProvider;

        //Constructors
        public CurrentUserService(AuthenticationStateProvider authenticationStateProvider)
        {
            _authenticationStateProvider = authenticationStateProvider;
            _authenticationStateProvider.AuthenticationStateChanged += async _ => await OnAuthenticationStateChangedAsync();
        }

        //Events
        public event AsyncDelegate AuthenticationStateChanged;

        //Properties
        public bool IsAuthenticated { get; private set; }
        public string Id { get; private set; }
        public string Name { get; private set; }
        public string Email { get; private set; }
        public string PhotoUrl { get; private set; }
        public IReadOnlyDictionary<string, string> Claims { get; private set; } = ImmutableDictionary<string, string>.Empty;

        //Methods
        private async Task OnAuthenticationStateChangedAsync()
        {
            if (AuthenticationStateChanged is null)
                return;

            await AuthenticationStateChanged.InvokeAsync();
        }

        public async Task CheckStateAsync()
        {
            //Get authentication state 
            var state = await _authenticationStateProvider.GetAuthenticationStateAsync();
            var claimsPrincipal = state?.User;

            //Extract information 
            IsAuthenticated = GetIsAuthenticated(claimsPrincipal);
            Id = GetId(claimsPrincipal);
            Name = GetName(claimsPrincipal);
            Email = GetEmail(claimsPrincipal);
            PhotoUrl = GetPhotoUrl(claimsPrincipal);
            Claims = GetClaims(claimsPrincipal);
        }

        private static bool GetIsAuthenticated(ClaimsPrincipal claimsPrincipal)
            => claimsPrincipal?.Identity?.IsAuthenticated is true;

        private static string GetId(ClaimsPrincipal claimsPrincipal)
            => GetClaimValue(claimsPrincipal, ClaimTypes.NameIdentifier);

        private static string GetName(ClaimsPrincipal claimsPrincipal)
            => GetClaimValue(claimsPrincipal, "nickname");

        private static string GetEmail(ClaimsPrincipal claimsPrincipal)
            => GetClaimValue(claimsPrincipal, ClaimTypes.Email);

        private static string GetPhotoUrl(ClaimsPrincipal claimsPrincipal)
            => GetClaimValue(claimsPrincipal, "picture");

        private static string GetClaimValue(ClaimsPrincipal claimsPrincipal, string claimType)
            => claimsPrincipal?.FindFirst(claimType)?.Value;

        private static IReadOnlyDictionary<string, string> GetClaims(ClaimsPrincipal claimsPrincipal)
        {
            var dictionary = claimsPrincipal?.Claims?.ToDictionary(c => c.Type, c => c.Value);
            return new ReadOnlyDictionary<string, string>(dictionary);
        }
    }
}
