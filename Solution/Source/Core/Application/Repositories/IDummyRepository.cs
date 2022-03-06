using CoreSharp.CleanStructure.Blazor.Domain.Entities;
using CoreSharp.EntityFramework.Repositories.Interfaces;

namespace CoreSharp.CleanStructure.Blazor.Application.Repositories
{
    public interface IDummyRepository : IExtendedRepository<Dummy>
    {
    }
}
