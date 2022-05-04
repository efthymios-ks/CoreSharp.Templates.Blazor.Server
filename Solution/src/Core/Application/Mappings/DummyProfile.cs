using CoreSharp.Templates.Blazor.Server.Application.Dto;
using CoreSharp.Templates.Blazor.Server.Application.Mappings.Abstracts;
using CoreSharp.Templates.Blazor.Server.Domain.Entities;

namespace CoreSharp.Templates.Blazor.Server.Application.Mappings
{
    public class DummyProfile : TwoWayProfileBase<Dummy, DummyDto>
    {
    }
}
