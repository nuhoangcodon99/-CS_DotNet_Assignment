namespace NWBC_Assignment05.Entities;

public class Student
{
    public int Id { get; set; }
    public string  Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public int GradeId { get; set; }
    
    public Grade Grade { get; set; }
    public ICollection<Course> Courses { get; set; } = new List<Course>();
}