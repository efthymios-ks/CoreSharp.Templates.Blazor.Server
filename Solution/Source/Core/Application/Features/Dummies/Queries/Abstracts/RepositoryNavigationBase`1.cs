using CoreSharp.EntityFramework.Delegates;

namespace CoreSharp.CleanStructure.Blazor.Application.Features.Dummies.Queries.Abstracts
{
    public abstract class RepositoryNavigationBase<TEntity>
    {
        //Properties
        public Query<TEntity> Navigation { get; init; }
    }
}
