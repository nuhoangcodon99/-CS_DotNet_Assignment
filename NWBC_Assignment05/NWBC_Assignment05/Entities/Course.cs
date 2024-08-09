using System.ComponentModel.DataAnnotations;

namespace NWBC_Assignment05.Entities;

public class Course
{

    public int Id { get; set; }

    public string Title { get; set; }

    public string Description { get; set; }

    public ICollection<Student> Students { get; set; } 
        // = new List<Student>();
}