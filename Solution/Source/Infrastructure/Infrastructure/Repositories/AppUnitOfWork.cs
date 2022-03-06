using CoreSharp.CleanStructure.Blazor.Infrastructure.Context;
using CoreSharp.CleanStructure.Blazor.Infrastructure.Repositories;
using CoreSharp.EntityFramework.Repositories.Abstracts;

namespace CoreSharp.CleanStructure.Blazor.Application.Repositories
{
    public class AppUnitOfWork : UnitOfWorkBase, IAppUnitOfWork
    {
        //Fields 
        private IDummyRepository _productRepository;

        //Constructors
        public AppUnitOfWork(AppDbContext dbContext)
            : base(dbContext)
        {
        }

        //Properties
        public IDummyRepository DummyRepository
            => _productRepository ??= new DummyRepository(Context);
    }
}
