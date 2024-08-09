using System.Linq.Expressions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services;

public class UserService : IBaseService<User>
{
    private UserRepository _userRepository;
    public void AddAsync(User entity)
    {
        _userRepository.Add(entity);
    }

    public void UpdateAsync(User entity)
    {
         _userRepository.Update(entity);
    }

    public void DeleteAsync(Guid id)
    {
         _userRepository.Delete(id);
    }

    public void DeleteAsync(User entity)
    {
         _userRepository.Delete(entity);
    }

    public Task<User?> GetByIdAsync(Guid id)
    {
        return _userRepository.GetByIdAsync(id);
    }

    public Task<IEnumerable<User>> GetAllAsync()
    {
        return _userRepository.GetAllAsync();
    }

    public Task<PaginatedResult<User>> GetAsync(Expression<Func<User, bool>>? filter = null, Func<IQueryable<User>, IOrderedQueryable<User>>? orderBy = null, string includeProperties = "", int pageIndex = 1,
        int pageSize = 10)
    {
        return null;
    }
}