using CoreSharp.EntityFramework.Repositories.Interfaces;
using CoreSharp.Templates.Blazor.Server.Domain.Entities;

namespace CoreSharp.Templates.Blazor.Server.Application.Repositories
{
    public interface IDummyRepository : IExtendedRepository<Dummy>
    {
    }
}
