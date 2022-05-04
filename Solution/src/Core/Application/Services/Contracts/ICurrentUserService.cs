using CoreSharp.Delegates;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoreSharp.Templates.Blazor.Server.Application.Services.Contracts
{
    public interface ICurrentUserService
    {
        //Properties
        bool IsAuthenticated { get; }
        string Id { get; }
        string Name { get; }
        string Email { get; }
        string PhotoUrl { get; }
        IReadOnlyDictionary<string, string> Claims { get; }

        //Events
        public event AsyncDelegate AuthenticationStateChanged;

        //Methods
        Task CheckStateAsync();
    }
}
