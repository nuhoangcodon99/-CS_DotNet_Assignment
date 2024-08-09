using System.Linq.Expressions;
using DataAccessLayer.Context;
using Microsoft.EntityFrameworkCore;

namespace BusinessLogicLayer;

public class GenericRepository<T> : IGenericRepository<T> where T : class 
{
    private readonly MyDbContext _context;
    private readonly DbSet<T> _dbSet;
    public GenericRepository(MyDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<T>();
    }    
   
    public  IEnumerable<T> GetAll()
    {
        return  _dbSet.ToList();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public T? GetById(Guid id)
    {
        return _dbSet.Find(id);
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async void Add(T entity)
    {
        _dbSet.Add(entity);
        await _context.SaveChangesAsync();
    }

    public async void Update(T entity)
    {
        _context.Entry(entity).State = EntityState.Modified;
        try
        {
            await _context.SaveChangesAsync();
           
        }
        catch (DbUpdateConcurrencyException)
        {
            throw new NotImplementedException();
        }
    }

    public async void Delete(Guid id)
    {
        T objects = await _dbSet.FindAsync(id);
        if (objects != null)
        {
            _dbSet.Remove(objects);
            await _context.SaveChangesAsync();
        }

    }

    public async void Delete(T? entity)
    {
        if (entity == null) return;
        _dbSet.Remove(entity);
        await _context.SaveChangesAsync();


    }

    public IQueryable<T> GetQuery()
    {
        return _dbSet.AsQueryable();
    }

    public IQueryable<T> GetQuery(Expression<Func<T, bool>> predicate)
    {
        return  _dbSet.Where(predicate);
    }

    public IQueryable<T> Get(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderBy = null, string includeProperties = "")
    {
        throw new NotImplementedException();
    }
}