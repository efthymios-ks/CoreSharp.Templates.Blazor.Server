﻿using CoreSharp.Templates.Blazor.Server.Application.Dto.Common;
using System;

namespace CoreSharp.Templates.Blazor.Server.Application.Dto;

public class DummyDto : DomainDtoBase<Guid>
{
    //Properties
    public string Name { get; set; }
    public string Description { get; set; }
}
