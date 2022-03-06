using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Constants;
using System;
using System.Net.Http;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Extensions
{
    /// <summary>
    /// <see cref="IHttpClientFactory"/> extensions.
    /// </summary>
    internal static class IHttpClientFactoryExtensions
    {
        public static HttpClient CreateAppApiClient(this IHttpClientFactory httpClientFactory)
        {
            _ = httpClientFactory ?? throw new ArgumentNullException(nameof(httpClientFactory));

            return httpClientFactory.CreateClient(Configuration.AppApiHttpClientName);
        }
    }
}
