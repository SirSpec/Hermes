using System.Linq.Expressions;

namespace Hermes.Frameworks.Repositories.Command;

public interface IDeleteByPredicateCommandRepository<TEntity>
{
    Task DeleteAsync(Expression<Func<TEntity, bool>> predicate, bool autoSave = false, CancellationToken cancellationToken = default);
}