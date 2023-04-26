using Microsoft.AspNetCore.Mvc;

namespace lec10.Models
{
    public class StudentRepository
    {
        public List<Student> _students = new List<Student>();
        public StudentRepository() {
            Student s1 = new Student
            {
                Id = 1,
                Name = "Ali",
                Semester = "6th"
            };
            Student s2 = new Student
            {
                Id = 2,
                Name = "Kamran",
                Semester = "6th"
            };
            _students.Add(s1);
            _students.Add(s2);
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
