using CoreSharp.CleanStructure.Blazor.Application.Dto;
using CoreSharp.CleanStructure.Blazor.Application.Features.Dummies.Queries;
using CoreSharp.Models.Pages;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Server.Controllers.V1
{
    [ApiVersion("1.0", Deprecated = true)]
    public class DummiesController : AppControllerBase
    {
        //Methods
        /// <inheritdoc cref="GetDummiesPageQuery"/>
        [HttpGet]
        public async Task<Page<DummyDto>> GetAsync([FromQuery] PageOptions pageParameter)
            => await Mediator.Send(new GetDummiesPageQuery(pageParameter.PageNumber, pageParameter.PageSize));
    }
}
