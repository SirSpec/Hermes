using System.Linq.Expressions;
using Hermes.Frameworks.Repositories.DataStructures;

namespace Hermes.Frameworks.Repositories.Query;

public interface IPaginationQueryRepository<TEntity>
{
    Task<List<TResult>> GetPageAsync<TResult>(
        Offset offset,
        Expression<Func<TEntity, TResult>> selector,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);

    Task<List<TResult>> GetPageAsync<TResult>(
        Keyset<TEntity> keyset,
        Expression<Func<TEntity, TResult>> selector,
        string sorting,
        bool includeDetails = false,
        CancellationToken cancellationToken = default);
}