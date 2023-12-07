using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Entities;
using UniversityManager.Utilities;

namespace UniversityManager.Services
{
    public class StudentService
    {
        List<Course> _courses;
        List<Student> _students;
        GenericRepository<Student> studentRepository;
        GenericRepository<Course> courseRepository;
        StudentService(string studentFilePath, string courseFilePath)
        {
            studentRepository = new GenericRepository<Student>(studentFilePath);
            courseRepository = new GenericRepository<Course>(courseFilePath);
            _students = studentRepository.GetAll();

        }        
        public List<Course> GetAllCourse()
        {
            return _courses;
        }
        public List<Course> GetStudentCourses(Guid studentId)
        {
            try
            {
                return _students.FirstOrDefault(s => s.id == studentId).courses;
            }
            catch
            {
                return new List<Course>();
            }
        }
        public bool TakeCourse(Guid studentId, Course course)
        {
            try
            {
                _students.FirstOrDefault(s => s.id == studentId).courses.Add(course);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
    }
}
