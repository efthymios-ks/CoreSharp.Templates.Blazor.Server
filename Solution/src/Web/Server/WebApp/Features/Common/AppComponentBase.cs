using CoreSharp.Blazor.Components.Common;
using CoreSharp.Templates.Blazor.Server.Application.Services.Contracts;
using MediatR;
using Microsoft.AspNetCore.Components;

namespace WebApp.Features.Common;

public abstract class AppComponentBase : PlainComponentBase
{
    //Properties
    [Inject]
    protected IMediator Mediator { get; set; }

    [Inject]
    protected IServerCurrentUserService CurrentUserService { get; set; }
}
