using CoreSharp.EntityFramework.Repositories.Interfaces;

namespace CoreSharp.CleanStructure.Blazor.Application.Repositories
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        //Properties
        IDummyRepository DummyRepository { get; }
    }
}
