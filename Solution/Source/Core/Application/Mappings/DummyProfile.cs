using CoreSharp.CleanStructure.Blazor.Application.Dto;
using CoreSharp.CleanStructure.Blazor.Application.Mappings.Abstracts;
using CoreSharp.CleanStructure.Blazor.Domain.Entities;

namespace CoreSharp.CleanStructure.Blazor.Application.Mappings
{
    public class DummyProfile : TwoWayProfileBase<Dummy, DummyDto>
    {
    }
}
