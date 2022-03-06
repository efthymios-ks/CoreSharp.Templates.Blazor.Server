using CoreSharp.AspNetCore.Extensions;
using CoreSharp.CleanStructure.Blazor.Application.Dto;
using CoreSharp.CleanStructure.Blazor.Application.Features.Dummies.Queries;
using CoreSharp.Models.Pages;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Server.Controllers.V2
{
    [ApiVersion("2.0")]
    public class DummiesController : AppControllerBase
    {
        //Methods
        /// <inheritdoc cref="GetDummyByIdQuery"/>
        [HttpGet("{id}")]
        public async Task<DummyDto> GetAsync(Guid id)
            => await Mediator.Send(new GetDummyByIdQuery(id));

        /// <inheritdoc cref="GetDummiesPageQuery"/>
        [HttpGet]
        public async Task<LinkedPage<DummyDto>> GetAsync([FromQuery] PageOptions pageParameter)
        {
            var page = await Mediator.Send(new GetDummiesPageQuery(pageParameter.PageNumber, pageParameter.PageSize));
            return this.GetLinkedPage(page);
        }

        /// <inheritdoc cref="CreateDummyCommand"/>
        [HttpPost]
        public async Task<DummyDto> CreateAsync(DummyDto dummyDto)
            => await Mediator.Send(new CreateDummyCommand(dummyDto));

        /// <inheritdoc cref="UpdateDummyCommand"/>
        [HttpPut]
        public async Task<DummyDto> UpdateAsync(DummyDto dummyDto)
            => await Mediator.Send(new UpdateDummyCommand(dummyDto));

        /// <inheritdoc cref="DeleteDummyCommand"/>
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
            => await Mediator.Send(new DeleteDummyCommand(id));
    }
}
