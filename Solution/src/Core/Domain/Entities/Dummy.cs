using CoreSharp.EntityFramework.Entities.Common;
using System;

namespace CoreSharp.Templates.Blazor.Server.Domain.Entities;

public class Dummy : EntityBase<Guid>
{
    //Properties
    public string Name { get; set; }
    public string Description { get; set; }
}
