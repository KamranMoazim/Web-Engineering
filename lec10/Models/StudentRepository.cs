using Microsoft.AspNetCore.Mvc;

namespace lec10.Models
{
    public class StudentRepository
    {
        public List<Student> _students = new List<Student>()
        {
            new Student
            {
                Id = 1,
                Name = "Ali",
                Semester = "6th"
            },
            new Student
            {
                Id = 2,
                Name = "Kamran",
                Semester = "6th"
            }

        };
        public StudentRepository()
        {
        }


        public Student GetStudent(int id)
        {
            return _students.Find(stu => stu.Id == id);
        }

        public List<Student> GetAllStudent()
        {
            return _students;
        }

    }
}
