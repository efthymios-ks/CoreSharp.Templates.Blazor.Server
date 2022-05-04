using CoreSharp.EntityFramework.Delegates;

namespace CoreSharp.Templates.Blazor.Server.Application.Features.Dummies.Queries.Abstracts
{
    public abstract class RepositoryNavigationBase<TEntity>
    {
        //Properties
        public Query<TEntity> Navigation { get; init; }
    }
}
