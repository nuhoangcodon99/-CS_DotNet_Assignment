using Microsoft.EntityFrameworkCore;
using NWBC_Assignment03.Entities;

namespace NWBC_Assignment03.DBContext;

public partial class MyDBContext : DbContext
{
    protected MyDBContext()
    {
    }

    public MyDBContext(DbContextOptions<MyDBContext> options) : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Grade> Grade { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasIndex(e => e.GradeId, "IX_Students_GradeId");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(500);

            entity.HasOne(d => d.Grade).WithMany(p => p.Students)
                .HasForeignKey(d => d.GradeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Student_Grade");
        });
        modelBuilder.Entity<Grade>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever().IsRequired();
            entity.Property(e => e.Name).HasMaxLength(500).IsRequired();
           
        });
        modelBuilder.Entity<Course>(entity =>
        {
            entity.Property(e => e.Id).IsRequired().ValueGeneratedNever();
            entity.Property(e => e.Title).IsRequired();
            entity.Property(e => e.Description);
            entity.HasMany(s => s.Students).WithMany(e => e.Courses).UsingEntity<Dictionary<string, object>>(
                "CourseStudent",
                r => r.HasOne<Student>().WithMany().HasForeignKey("StudentsId"),
                l => l.HasOne<Course>().WithMany().HasForeignKey("CoursesId"),
                j =>
                {
                    j.HasKey("CoursesId", "StudentsId");
                    j.ToTable("CourseStudent");
                    j.HasIndex(new[] { "StudentsId" }, "IX_CourseStudent_StudentsId");
                });
        });
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}