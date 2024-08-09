using Microsoft.EntityFrameworkCore;
using QuizApp.WebAPI.Data;
using QuizApp.WebAPI.Models;

namespace QuizApp.WebAPI._Repositories;

public class QuizRepository : IQuizRepository
{
    private readonly QuizAppDbContext _context;

    public QuizRepository(QuizAppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Quiz>> GetAll()
    {
        return await _context.Quizzes.ToListAsync();
    }

    public async Task<Quiz?> GetById(Guid Id)
    {
        return await _context.Quizzes.FindAsync(Id);
    }

    public async Task<int> Add(Quiz entity)
    {
        _context.Quizzes.Add(entity);
        return await _context.SaveChangesAsync();
        
    }

    public async Task<bool> Update(Quiz entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
            return true;
        }
        catch (DbUpdateConcurrencyException)
        {
            if (GetById(entity.Id) == null)
            {
                return false;
            }
            else
            {
                throw;
            }

        }
    }

    public async Task<bool> DeleteById(Guid id)
    {
        var quiz = await _context.Quizzes.FindAsync(id);
        if (quiz != null)
        {
            _context.Quizzes.Remove(quiz);
            await _context.SaveChangesAsync();
        }

        return true;
    }

    public async Task<bool> Delete(Quiz entity)
    {
        if (entity != null)
        {
            _context.Quizzes.Remove(entity);
            await _context.SaveChangesAsync();
        }

        return true;
    }
}