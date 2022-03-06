using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Features.Common.Abstracts;
using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Services.Contracts;
using Microsoft.AspNetCore.Components;

namespace CoreSharp.CleanStructure.Blazor.Client.Features.Common.Abstracts
{
    public abstract class AppComponentBase : RazorComponentBase
    {
        //Properties
        [Inject]
        protected IAppContextService AppContext { get; set; }
    }
}
