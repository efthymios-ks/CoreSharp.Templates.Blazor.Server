using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CoreSharp.CleanStructure.Blazor.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public abstract class AppControllerBase : ControllerBase
    {
        //Fields
        private IMediator _mediator;

        //Properties
        protected IMediator Mediator
            => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
    }
}
