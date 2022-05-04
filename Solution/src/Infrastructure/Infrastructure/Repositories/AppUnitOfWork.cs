using CoreSharp.EntityFramework.Repositories.Abstracts;
using CoreSharp.Templates.Blazor.Server.Application.Repositories;
using CoreSharp.Templates.Blazor.Server.Infrastructure.Context;

namespace CoreSharp.Templates.Blazor.Server.Infrastructure.Repositories
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
