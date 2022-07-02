using CoreSharp.EntityFramework.Repositories.Common;
using CoreSharp.Templates.Blazor.Server.Application.Repositories;
using CoreSharp.Templates.Blazor.Server.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreSharp.Templates.Blazor.Server.Infrastructure.Repositories;

public class DummyRepository : ExtendedRepositoryBase<Dummy>, IDummyRepository
{
    //Constructors
    public DummyRepository(DbContext dbContext)
        : base(dbContext)
    {
    }
}
