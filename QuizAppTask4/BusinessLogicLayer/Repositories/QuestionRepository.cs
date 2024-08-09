using System.Linq.Expressions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer;

public class QuestionRepository : IGenericRepository<Question>
{
    private IGenericRepository<Question> _genericRepositoryImplementation;
    public IEnumerable<Question> GetAll()
    {
        return _genericRepositoryImplementation.GetAll();
    }

    public Task<IEnumerable<Question>> GetAllAsync()
    {
        return _genericRepositoryImplementation.GetAllAsync();
    }

    public Question? GetById(Guid id)
    {
        return _genericRepositoryImplementation.GetById(id);
    }

    public Task<Question?> GetByIdAsync(Guid id)
    {
        return _genericRepositoryImplementation.GetByIdAsync(id);
    }

    public void Add(Question entity)
    {
        _genericRepositoryImplementation.Add(entity);
    }

    public void Update(Question entity)
    {
        _genericRepositoryImplementation.Update(entity);
    }

    public void Delete(Guid id)
    {
        _genericRepositoryImplementation.Delete(id);
    }

    public void Delete(Question entity)
    {
        _genericRepositoryImplementation.Delete(entity);
    }

    public IQueryable<Question> GetQuery()
    {
        return _genericRepositoryImplementation.GetQuery();
    }

    public IQueryable<Question> GetQuery(Expression<Func<Question, bool>> predicate)
    {
        return _genericRepositoryImplementation.GetQuery(predicate);
    }

    public IQueryable<Question> Get(Expression<Func<Question, bool>>? filter = null, Func<IQueryable<Question>, IOrderedQueryable<Question>>? orderBy = null, string includeProperties = "")
    {
        return _genericRepositoryImplementation.Get(filter, orderBy, includeProperties);
    }
}