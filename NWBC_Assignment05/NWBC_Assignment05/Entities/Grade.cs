namespace NWBC_Assignment05.Entities;

public class Grade
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Student> Students { get; set; } = new List<Student>();
}