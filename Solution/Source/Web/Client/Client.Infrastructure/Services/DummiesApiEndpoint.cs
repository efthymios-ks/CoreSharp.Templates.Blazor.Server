using CoreSharp.CleanStructure.Blazor.Application.Dto;
using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Extensions;
using CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Services.Abstracts;
using CoreSharp.Http.FluentApi.Extensions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CoreSharp.CleanStructure.Blazor.Client.Infrastructure.Services
{
    public class DummiesApiEndpoint : ApiEndpointBase
    {
        //Constructors
        public DummiesApiEndpoint(IHttpClientFactory httpClientFactory)
            : base(httpClientFactory.CreateAppApiClient())
        {
        }

        //Properties
        protected override string Route
            => "api/dummies";

        //Methods
        public async Task<DummyDto> GetAsync(Guid id)
            => await Client.Request()
                           .Route(Route, id)
                           .Get()
                           .Json<DummyDto>()
                           .SendAsync();

        public async Task<IEnumerable<DummyDto>> GetAsync()
            => await Client.Request()
                           .Route(Route)
                           .Get()
                           .Json<IEnumerable<DummyDto>>()
                           .SendAsync();

        public async Task<DummyDto> CreateAsync(DummyDto dummyDto)
            => await Client.Request()
                           .Route(Route)
                           .Post()
                           .JsonContent(dummyDto)
                           .Json<DummyDto>()
                           .SendAsync();

        public async Task<DummyDto> UpdateAsync(DummyDto dummyDto)
            => await Client.Request()
                           .Route(Route)
                           .Put()
                           .JsonContent(dummyDto)
                           .Json<DummyDto>()
                           .SendAsync();

        public async Task DeleteAsync(Guid id)
            => await Client.Request()
                           .Route(Route, id)
                           .Delete()
                           .SendAsync();
    }
}
