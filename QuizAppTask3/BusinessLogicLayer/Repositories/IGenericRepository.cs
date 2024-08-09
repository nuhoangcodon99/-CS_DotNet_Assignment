using System.Linq.Expressions;

namespace BusinessLogicLayer;

public interface IGenericRepository<T>
{
    public IEnumerable<T> GetAll();
    public Task<IEnumerable<T>> GetAllAsync();
    public T? GetById(Guid id);
    public Task<T?> GetByIdAsync(Guid id);
    public void Add(T entity);
    public void Update(T entity);
    public void Delete(Guid id);
    public void Delete(T entity);
    public IQueryable<T> GetQuery();
    public IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate);
    public IQueryable<T> Get(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "");
}