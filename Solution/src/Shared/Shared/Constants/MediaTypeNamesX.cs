using System.Net.Mime;

namespace CoreSharp.Templates.Blazor.Server.Shared.Constants;

/// <inheritdoc cref="MediaTypeNames"/>
public static class MediaTypeNamesX
{
    /// <inheritdoc cref="MediaTypeNames.Application"/>
    public static class Application
    {
        public const string ProblemJson = "application/problem+json";
        public const string ProblemXml = "application/problem+xml";
    }
}
