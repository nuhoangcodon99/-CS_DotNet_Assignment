using Microsoft.EntityFrameworkCore;
using QuizApp.WebAPI.Models;
namespace QuizApp.WebAPI.Data;

public partial class QuizAppDbContext : DbContext
{
    protected QuizAppDbContext()
    {
    }

    public QuizAppDbContext(DbContextOptions<QuizAppDbContext> options) : base(options)
    {
    }
    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }

    public virtual DbSet<QuizUser> QuizUsers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LEA02;Database=QuizApp;Integrated Security=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Answer>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Content).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Question>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IsActive).HasDefaultValue(true);
        });

        modelBuilder.Entity<Quiz>(entity =>
        {
            entity.ToTable("Quiz");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.ThumbnailUrl).HasMaxLength(500);
            entity.Property(e => e.Tile).HasMaxLength(255);
        });

        modelBuilder.Entity<QuizQuestion>(entity =>
        {
            entity.HasKey(e => new { e.QuizId, e.QuestionId }).HasName("PK_QuizQuestion_1");

            entity.ToTable("QuizQuestion");

            entity.HasOne(d => d.Question).WithMany(p => p.QuizQuestions)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuizQuestion_Questions");

            entity.HasOne(d => d.Quiz).WithMany(p => p.QuizQuestions)
                .HasForeignKey(d => d.QuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_QuizQuestion_Quiz");
        });

        modelBuilder.Entity<QuizUser>(entity =>
        {
            entity.HasKey(e => new { e.QuizzesId, e.UsersId });

            entity.ToTable("QuizUser");

            entity.HasIndex(e => e.UsersId, "IX_QuizUser_UsersId");

            entity.Property(e => e.FinishedAt)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.StartedAt).HasColumnType("datetime");

            entity.HasOne(d => d.Quizzes).WithMany(p => p.QuizUsers).HasForeignKey(d => d.QuizzesId);

            entity.HasOne(d => d.Users).WithMany(p => p.QuizUsers).HasForeignKey(d => d.UsersId);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);

            entity.HasMany(d => d.Users).WithMany(p => p.Roles)
                .UsingEntity<Dictionary<string, object>>(
                    "RoleUser",
                    r => r.HasOne<User>().WithMany().HasForeignKey("UsersId"),
                    l => l.HasOne<Role>().WithMany().HasForeignKey("RolesId"),
                    j =>
                    {
                        j.HasKey("RolesId", "UsersId");
                        j.ToTable("RoleUser");
                        j.HasIndex(new[] { "UsersId" }, "IX_RoleUser_UsersId");
                    });
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Avatar).HasMaxLength(500);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });
        // modelBuilder.Entity<Quiz>().HasData(
        //     new Quiz { Id = Guid.NewGuid(), Tile = "Quiz 1", Description = "Description 1", Duration = 60, ThumbnailUrl = "url1" },
        //     new Quiz { Id = Guid.NewGuid(), Tile = "Quiz 2", Description = "Description 2", Duration = 90, ThumbnailUrl = "url2" },
        //     new Quiz { Id = Guid.NewGuid(), Tile = "Quiz 3", Description = "Description 3", Duration = 120, ThumbnailUrl = "url3" },
        //     new Quiz { Id = Guid.NewGuid(), Tile = "Quiz 4", Description = "Description 4", Duration = 150, ThumbnailUrl = "url4" },
        //     new Quiz { Id = Guid.NewGuid(), Tile = "Quiz 5", Description = "Description 5", Duration = 180, ThumbnailUrl = "url5" }
        // );
        //
        // modelBuilder.Entity<Question>().HasData(
        //     new Question { Id = Guid.NewGuid(), Content = "Question 1", QuestionType = "MultipleChoice" },
        //     new Question { Id = Guid.NewGuid(), Content = "Question 2", QuestionType = "MultipleChoice" },
        //     new Question { Id = Guid.NewGuid(), Content = "Question 3", QuestionType = "MultipleChoice" },
        //     new Question { Id = Guid.NewGuid(), Content = "Question 4", QuestionType = "MultipleChoice" },
        //     new Question { Id = Guid.NewGuid(), Content = "Question 5", QuestionType = "MultipleChoice" }
        // );
        //
        // modelBuilder.Entity<Answer>().HasData(
        //     new Answer { Id = Guid.NewGuid(), Content = "Answer 1", IsCorrect = true },
        //     new Answer { Id = Guid.NewGuid(), Content = "Answer 2", IsCorrect = false},
        //     new Answer { Id = Guid.NewGuid(), Content = "Answer 3", IsCorrect = true },
        //     new Answer { Id = Guid.NewGuid(), Content = "Answer 4", IsCorrect = false },
        //     new Answer { Id = Guid.NewGuid(), Content = "Answer 5", IsCorrect = true }
        // );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}