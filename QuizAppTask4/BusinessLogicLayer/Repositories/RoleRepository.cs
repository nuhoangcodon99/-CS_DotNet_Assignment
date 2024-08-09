using System.Linq.Expressions;
using DataAccessLayer.Context;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer;

public class RoleRepository : IGenericRepository<Role>
{
    private GenericRepository<Role> _genericRepositoryImplementation;
    public IEnumerable<Role> GetAll()
    {
        return _genericRepositoryImplementation.GetAll();
    }

    public Task<IEnumerable<Role>> GetAllAsync()
    {
        return _genericRepositoryImplementation.GetAllAsync();
    }

    public Role? GetById(Guid id)
    {
        return _genericRepositoryImplementation.GetById(id);
    }

    public Task<Role?> GetByIdAsync(Guid id)
    {
        return _genericRepositoryImplementation.GetByIdAsync(id);
    }

    public void Add(Role entity)
    {
        _genericRepositoryImplementation.Add(entity);
    }

    public void Update(Role entity)
    {
        _genericRepositoryImplementation.Update(entity);
    }

    public void Delete(Guid id)
    {
        _genericRepositoryImplementation.Delete(id);
    }

    public void Delete(Role entity)
    {
        _genericRepositoryImplementation.Delete(entity);
    }

    public IQueryable<Role> GetQuery()
    {
        return _genericRepositoryImplementation.GetQuery();
    }

    public IQueryable<Role> GetQuery(Expression<Func<Role, bool>> predicate)
    {
        return _genericRepositoryImplementation.GetQuery(predicate);
    }

    public IQueryable<Role> Get(Expression<Func<Role, bool>>? filter = null, Func<IQueryable<Role>, IOrderedQueryable<Role>>? orderBy = null, string includeProperties = "")
    {
        return _genericRepositoryImplementation.Get(filter, orderBy, includeProperties);
    }


}