using QuizApp.WebAPI.Models;

namespace QuizApp.WebAPI._Repositories;

public interface IQuizRepository
{
    public Task<IEnumerable<Quiz>> GetAll();
    public Task<Quiz?> GetById(Guid Id);
    public Task<int> Add(Quiz entity);
    public Task<bool> Update(Quiz entity);
    public Task<bool> DeleteById(Guid id);
    public Task<bool> Delete(Quiz entity);
}