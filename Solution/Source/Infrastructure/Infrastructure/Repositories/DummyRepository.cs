using CoreSharp.CleanStructure.Blazor.Application.Repositories;
using CoreSharp.CleanStructure.Blazor.Domain.Entities;
using CoreSharp.EntityFramework.Repositories.Abstracts;
using Microsoft.EntityFrameworkCore;

namespace CoreSharp.CleanStructure.Blazor.Infrastructure.Repositories
{
    public class DummyRepository : ExtendedRepositoryBase<Dummy>, IDummyRepository
    {
        //Constructors
        public DummyRepository(DbContext dbContext)
            : base(dbContext)
        {
        }
    }
}
