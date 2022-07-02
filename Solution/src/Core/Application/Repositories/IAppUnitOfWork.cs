using CoreSharp.EntityFramework.Repositories.Interfaces;

namespace CoreSharp.Templates.Blazor.Server.Application.Repositories;

public interface IAppUnitOfWork : IUnitOfWork
{
    //Properties
    IDummyRepository DummyRepository { get; }
}
