using DataAccessLayer.Context;
using DataAccessLayer.Entities;

namespace BusinessLogicLayer.UnitOfWork;

public interface IUnitOfWork
{
    MyDbContext Context { get; }
    IGenericRepository<Quiz> QuizRepository { get; }
    IGenericRepository<Question> QuestionRepository { get; }
    IGenericRepository<QuizUser> UserQuizRepository { get; }
    IGenericRepository<QuizQuestion> QuizQuestionRepository { get; }
    IGenericRepository<UserAnswer> UserAnswerRepository { get; }
    IGenericRepository<User> UserRepository { get; }
    IGenericRepository<Role> RoleRepository { get; }
    IGenericRepository<Answer> AnswerRepository { get; }
    IGenericRepository<TEntity> GenericRepository<TEntity>() where TEntity : class; 
    int SaveChanges();
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}