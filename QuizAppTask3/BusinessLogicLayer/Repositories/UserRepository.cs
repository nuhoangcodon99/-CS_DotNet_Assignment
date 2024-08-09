using System.Linq.Expressions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer;

public class UserRepository : IGenericRepository<User>
{
    private GenericRepository<User> _genericRepositoryImplementation;
    public IEnumerable<User> GetAll()
    {
        return _genericRepositoryImplementation.GetAll();
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        return _genericRepositoryImplementation.GetAllAsync();
    }

    public User? GetById(Guid id)
    {
        return _genericRepositoryImplementation.GetById(id);
    }

    public Task<User?> GetByIdAsync(Guid id)
    {
        return _genericRepositoryImplementation.GetByIdAsync(id);
    }

    public void Add(User entity)
    {
        _genericRepositoryImplementation.Add(entity);
    }

    public void Update(User entity)
    {
        _genericRepositoryImplementation.Update(entity);
    }

    public void Delete(Guid id)
    {
        _genericRepositoryImplementation.Delete(id);
    }

    public void Delete(User entity)
    {
        _genericRepositoryImplementation.Delete(entity);
    }

    public IQueryable<User> GetQuery()
    {
        return _genericRepositoryImplementation.GetQuery();
    }

    public IQueryable<User> GetQuery(Expression<Func<User, bool>> predicate)
    {
        return _genericRepositoryImplementation.GetQuery(predicate);
    }

    public IQueryable<User> Get(Expression<Func<User, bool>>? filter = null, Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null, string includeProperties = "")
    {
        return _genericRepositoryImplementation.Get(filter, orderBy, includeProperties);
    }
}