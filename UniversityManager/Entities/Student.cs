using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityManager.Entities
{
    public class Student:Person
    {
        public Student()
        {
            courses = new List<Course>();
        }

        public List<Course> courses { get; set; }
    }
}
