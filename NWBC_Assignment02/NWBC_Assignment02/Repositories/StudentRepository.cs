using NWBC_Assignment02.DBContext;
using NWBC_Assignment02.Entities;

namespace NWBC_Assignment02.Repositories;


    public static class StudentRepository
    {
        private static readonly List<Student> Students = new List<Student>
        {
            new Student { Id = 1, Name = "John Doe", Age = 20, Major = "Computer Science" },
            new Student { Id = 2, Name = "Jane Smith", Age = 22, Major = "Mathematics" }
        };

        public static List<Student> GetAllStudents() => Students;

        public static Student GetStudent(int id) => Students.FirstOrDefault(s => s.Id == id);

        public static void AddStudent(Student student)
        {
            student.Id = Students.Max(s => s.Id) + 1;
            Students.Add(student);
        }

        public static bool UpdateStudent(int id, Student student)
        {
            var existingStudent = GetStudent(id);
            if (existingStudent == null)
            {
                return false;
            }

            existingStudent.Name = student.Name;
            existingStudent.Age = student.Age;
            existingStudent.Major = student.Major;
            return true;
        }

        public static bool DeleteStudent(int id)
        {
            var student = GetStudent(id);
            if (student == null)
            {
                return false;
            }

            Students.Remove(student);
            return true;
        }
    }

