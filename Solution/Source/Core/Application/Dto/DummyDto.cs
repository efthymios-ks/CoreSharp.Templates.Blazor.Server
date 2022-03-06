using CoreSharp.CleanStructure.Blazor.Application.Dto.Abstracts;
using System;

namespace CoreSharp.CleanStructure.Blazor.Application.Dto
{
    public class DummyDto : DomainDtoBase<Guid>
    {
        //Properties
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
