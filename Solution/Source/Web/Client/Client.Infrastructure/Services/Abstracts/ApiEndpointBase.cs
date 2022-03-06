using System;
using System.Net.Http;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Services.Abstracts
{
    public abstract class ApiEndpointBase
    {
        //Constructors 
        //Constructors
        protected ApiEndpointBase(HttpClient client)
            => Client = client ?? throw new ArgumentNullException(nameof(client));

        //Properties
        protected HttpClient Client { get; }

        //Properties
        protected virtual string Route { get; }
    }
}
