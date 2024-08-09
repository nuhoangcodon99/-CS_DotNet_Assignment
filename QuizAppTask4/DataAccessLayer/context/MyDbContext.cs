using System;
using System.Collections.Generic;
using DataAccessLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Context;

public partial class MyDbContext : DbContext
{
    public MyDbContext()
    {
    }

    public MyDbContext(DbContextOptions<MyDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Answer> Answers { get; set; }

    public virtual DbSet<Question> Questions { get; set; }

    public virtual DbSet<Quiz> Quizzes { get; set; }

    public virtual DbSet<QuizQuestion> QuizQuestions { get; set; }

    public virtual DbSet<QuizUser> QuizUsers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserAnswer> UserAnswers { get; set; }

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
            entity.ToTable("QuizUser");

            entity.HasIndex(e => e.UsersId, "IX_QuizUser_UsersId");

            entity.Property(e => e.Id).ValueGeneratedNever();
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

        modelBuilder.Entity<UserAnswer>(entity =>
        {
            entity.ToTable("UserAnswer");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.Answer).WithMany(p => p.UserAnswers)
                .HasForeignKey(d => d.AnswerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAnswer_Answers");

            entity.HasOne(d => d.Question).WithMany(p => p.UserAnswers)
                .HasForeignKey(d => d.QuestionId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAnswer_Questions");

            entity.HasOne(d => d.UserQuiz).WithMany(p => p.UserAnswers)
                .HasForeignKey(d => d.UserQuizId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_UserAnswer_QuizUser");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
