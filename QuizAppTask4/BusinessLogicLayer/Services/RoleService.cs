using System.Linq.Expressions;
using BusinessLogicLayer.UnitOfWork;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services;

public class RoleService : IBaseService<Role>
{
    public RoleRepository _roleRepository;
    
    public void AddAsync(Role entity)
    {
         _roleRepository.Add(entity);
    }

    public void UpdateAsync(Role entity)
    {
        
         _roleRepository.Update(entity);
    }
    

    public void DeleteAsync(Guid id)
    {
         _roleRepository.Delete(id);
    }

    public void DeleteAsync(Role entity)
    {
         _roleRepository.Delete(entity);
    }

    public Task<Role?> GetByIdAsync(Guid id)
    {
        return _roleRepository.GetByIdAsync(id);
    }

    public Task<IEnumerable<Role>> GetAllAsync()
    {
        return _roleRepository.GetAllAsync();
    }

    public Task<PaginatedResult<Role>> GetAsync(Expression<Func<Role, bool>>? filter = null, Func<IQueryable<Role>, IOrderedQueryable<Role>>? orderBy = null, string includeProperties = "", int pageIndex = 1,
        int pageSize = 10)
    {
        return null;
    }

    // public Task<PaginatedResult<Role>> GetAsync(Expression<Func<Role, bool>>? filter = null, Func<IQueryable<Role>, IOrderedQueryable<Role>>? orderBy = null, string includeProperties = "", int pageIndex = 1,
    //     int pageSize = 10)
    // {
    //     return _roleRepository.GetQuery(filter, orderBy, includeProperties);
    // }
}