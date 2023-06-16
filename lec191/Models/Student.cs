using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lec191.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Courses { get; set; }
    }
}