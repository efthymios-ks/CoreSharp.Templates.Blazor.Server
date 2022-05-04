using CoreSharp.Blazor.Components.Common.Abstracts;
using CoreSharp.Templates.Blazor.Server.Application.Services.Contracts;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace WebApp.Features.Common.Abstracts
{
    public abstract class AppComponentBase : PlainComponentBase
    {
        //Properties
        [Inject]
        protected IMediator Mediator { get; set; }

        [Inject]
        protected ICurrentUserService CurrentUserService { get; set; }
    }
}
