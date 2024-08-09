using System.Linq.Expressions;

namespace BusinessLogicLayer.Services;

public interface IBaseService<T>
{
    void AddAsync(T entity);
    void UpdateAsync(T entity);
    void DeleteAsync(Guid id);
    void DeleteAsync(T entity);
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task<PaginatedResult<T>> GetAsync(Expression<Func<T, bool>>? filter = null,
    Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string
    includeProperties = "", int pageIndex = 1, int pageSize = 10);
}