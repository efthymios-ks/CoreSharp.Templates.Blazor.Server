using System.Collections.Generic;

namespace CoreSharp.CleanStructure.Blazor.Server.Services.Contracts
{
    internal interface ICurrentUserService
    {
        //Properties
        public string UserId { get; }
        public string UserEmail { get; }
        public IDictionary<string, string> Claims { get; }
    }
}
