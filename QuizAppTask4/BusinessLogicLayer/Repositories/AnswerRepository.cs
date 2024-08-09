using System.Linq.Expressions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer;

public class AnswerRepository : IGenericRepository<Answer>
{
    private GenericRepository<Answer> _genericRepositoryImplementation;
    public IEnumerable<Answer> GetAll()
    {
        return _genericRepositoryImplementation.GetAll();
    }

    public Task<IEnumerable<Answer>> GetAllAsync()
    {
        return _genericRepositoryImplementation.GetAllAsync();
    }

    public Answer? GetById(Guid id)
    {
        return _genericRepositoryImplementation.GetById(id);
    }

    public Task<Answer?> GetByIdAsync(Guid id)
    {
        return _genericRepositoryImplementation.GetByIdAsync(id);
    }

    public void Add(Answer entity)
    {
        _genericRepositoryImplementation.Add(entity);
    }

    public void Update(Answer entity)
    {
        _genericRepositoryImplementation.Update(entity);
    }

    public void Delete(Guid id)
    {
        _genericRepositoryImplementation.Delete(id);
    }

    public void Delete(Answer entity)
    {
        _genericRepositoryImplementation.Delete(entity);
    }

    public IQueryable<Answer> GetQuery()
    {
        return _genericRepositoryImplementation.GetQuery();
    }

    public IQueryable<Answer> GetQuery(Expression<Func<Answer, bool>> predicate)
    {
        return _genericRepositoryImplementation.GetQuery(predicate);
    }

    public IQueryable<Answer> Get(Expression<Func<Answer, bool>>? filter = null, Func<IQueryable<Answer>, IOrderedQueryable<Answer>>? orderBy = null, string includeProperties = "")
    {
        return _genericRepositoryImplementation.Get(filter, orderBy, includeProperties);
    }
}