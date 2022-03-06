using CoreSharp.EntityFramework.Models.Abstracts;
using System;

namespace CoreSharp.CleanStructure.Blazor.Domain.Entities
{
    public class Dummy : EntityBase<Guid>
    {
        //Properties
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
