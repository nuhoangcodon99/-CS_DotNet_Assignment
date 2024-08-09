using Microsoft.EntityFrameworkCore;
using QuizApp.WebAPI.Models;
namespace QuizApp.WebAPI.Data;

public class QuizAppDbContext : DbContext
{
    protected QuizAppDbContext()
    {
    }

    public QuizAppDbContext(DbContextOptions<QuizAppDbContext> options) : base(options)
    {
    }
    public virtual DbSet<Quiz> Quizs {get; set; }
    public virtual DbSet<Question> Questions {get; set; }
    public virtual DbSet<Answer> Answers {get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=LEA02;Database=QuizApp;Integrated Security=true;TrustServerCertificate=true");
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Quiz>(entity =>
        {
            
        });
        modelBuilder.Entity<Question>(entity =>
        {
            // entity.Property(e => e.QuestionType)
        });
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.Property(e => e.IsCorrect).HasDefaultValue(false);
        });
    }
}