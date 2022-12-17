using System.Collections;
using Hermes.Frameworks.Repositories.Constants;

namespace Hermes.Frameworks.Repositories.DataStructures;

public record Page<T> : IReadOnlyList<T>
{
    public Page(IReadOnlyList<T> pageCollection, int totalCount, int pageIndex, int pageSize)
    {
        _collection = pageCollection.Count <= totalCount && pageCollection.Count <= pageSize
            ? pageCollection
            : throw new ArgumentException(ErrorCodes.InvalidListCount, nameof(pageCollection));

        Count = totalCount;
        PageIndex = pageIndex >= 0 ? pageIndex : throw new ArgumentException(ErrorCodes.InvalidPageIndex, nameof(pageIndex));
        PageSize = pageSize > 0 ? pageSize : throw new ArgumentException(ErrorCodes.InvalidPageSize, nameof(pageSize));
        TotalPages = (int)Math.Ceiling(totalCount / (double)pageSize);
    }

    public T this[int index] =>
        _collection[index];

    private IReadOnlyList<T> _collection { get; }
    public int PageIndex { get; }
    public int PageSize { get; }
    public int TotalPages { get; }
    public int Count { get; }

    public IEnumerator<T> GetEnumerator() =>
        _collection.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() =>
        _collection.GetEnumerator();
}