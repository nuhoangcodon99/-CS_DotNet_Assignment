using System.Linq.Expressions;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.Services;

public class QuizService : IBaseService<Quiz>
{
    private QuizRepository _quizRepository;
    public void AddAsync(Quiz entity)
    {
        _quizRepository.Add(entity);
    }

    public void UpdateAsync(Quiz entity)
    {
        _quizRepository.Update(entity);
    }

    public void DeleteAsync(Guid id)
    {
        _quizRepository.Delete(id);
    }

    public void DeleteAsync(Quiz entity)
    {
        _quizRepository.Delete(entity);
    }

    public Task<Quiz?> GetByIdAsync(Guid id)
    {
        return _quizRepository.GetByIdAsync(id);
    }

    public Task<IEnumerable<Quiz>> GetAllAsync()
    {
        return _quizRepository.GetAllAsync();
    }

    public Task<PaginatedResult<Quiz>> GetAsync(Expression<Func<Quiz, bool>>? filter = null, Func<IQueryable<Quiz>, IOrderedQueryable<Quiz>>? orderBy = null, string includeProperties = "", int pageIndex = 1,
        int pageSize = 10)
    {
        return _quizRepository.GetQuery(filter, orderBy, includeProperties, pageIndex, pageSize);
    }
}