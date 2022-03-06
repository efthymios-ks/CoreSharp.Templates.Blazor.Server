using System;
using System.Collections.Generic;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Services.Contracts
{
    public interface IAppContextService
    {
        //Properties 
        IDictionary<string, object> Variables { get; }

        //Events
        event Action StateHasChangedRequested;
    }
}
