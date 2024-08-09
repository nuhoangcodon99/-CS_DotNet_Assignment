using System.Linq.Expressions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer;

public class QuizRepository : IGenericRepository<Quiz>
{
    private GenericRepository<Quiz> _genericRepositoryImplementation;
    public IEnumerable<Quiz> GetAll()
    {
        return _genericRepositoryImplementation.GetAll();
    }

    public Task<IEnumerable<Quiz>> GetAllAsync()
    {
        return _genericRepositoryImplementation.GetAllAsync();
    }

    public Quiz? GetById(Guid id)
    {
        return _genericRepositoryImplementation.GetById(id);
    }

    public Task<Quiz?> GetByIdAsync(Guid id)
    {
        return _genericRepositoryImplementation.GetByIdAsync(id);
    }

    public void Add(Quiz entity)
    {
        _genericRepositoryImplementation.Add(entity);
    }

    public void Update(Quiz entity)
    {
        _genericRepositoryImplementation.Update(entity);
    }

    public void Delete(Guid id)
    {
        _genericRepositoryImplementation.Delete(id);
    }

    public void Delete(Quiz entity)
    {
        _genericRepositoryImplementation.Delete(entity);
    }

    public IQueryable<Quiz> GetQuery()
    {
        return _genericRepositoryImplementation.GetQuery();
    }

    public IQueryable<Quiz> GetQuery(Expression<Func<Quiz, bool>> predicate)
    {
        return _genericRepositoryImplementation.GetQuery(predicate);
    }

    public IQueryable<Quiz> Get(Expression<Func<Quiz, bool>>? filter = null, Func<IQueryable<Quiz>, IOrderedQueryable<Quiz>>? orderBy = null, string includeProperties = "")
    {
        return _genericRepositoryImplementation.Get(filter, orderBy, includeProperties);
    }

    public Task<PaginatedResult<Quiz>> GetQuery(Expression<Func<Quiz, bool>>? predicate, Func<IQueryable<Quiz>, IOrderedQueryable<Quiz>>? orderBy, string includeProperties, int pageIndex, int pageSize)
    {
        throw new NotImplementedException();
    }
}