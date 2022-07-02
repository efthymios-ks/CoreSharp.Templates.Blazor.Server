using System.Collections.Generic;

namespace CoreSharp.Templates.Blazor.Server.Application.Services.Contracts;

public interface ICurrentUserService
{
    //Properties
    bool IsAuthenticated { get; }
    string Id { get; }
    string Name { get; }
    string Email { get; }
    IReadOnlyDictionary<string, string> Claims { get; }
}
