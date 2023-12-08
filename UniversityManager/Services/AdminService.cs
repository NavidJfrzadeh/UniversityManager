using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityManager.Entities;
using UniversityManager.Utilities;

namespace UniversityManager.Services
{
    public class AdminService
    {
        List<Course> _courses;
        List<Student> _students;
        List<Admin> _admin;
        GenericRepository<Student> studentRepository;
        GenericRepository<Course> courseRepository;
        GenericRepository<Admin> adminRepository;
        public AdminService(string studentFilePath, string courseFilePath, string adminFilePath)
        {
            studentRepository = new GenericRepository<Student>(studentFilePath);
            courseRepository = new GenericRepository<Course>(courseFilePath);
            adminRepository = new GenericRepository<Admin>(adminFilePath);
            _students = studentRepository.GetAll();
            _courses = courseRepository.GetAll();
            _admin = adminRepository.GetAll();
        }

        public Course Create(Course newCourse)
        {
            _courses.Add(newCourse);
            Console.WriteLine("course created.");
            return newCourse;
        }

        public List<Course> GetAll()
        {
            return _courses;
        }

        public List<Student> StudentsCourse(string CourseName)
        {
            return _students.Where(s => s.courses.Any(c =>c.name == CourseName)).ToList();
        }

        public Course Update(Course newCourse)
        {
            var targetCourse = _courses.FirstOrDefault(c => c.id == newCourse.id);
            targetCourse = newCourse;
            return targetCourse;
        }
        public bool Delete(Guid courseId)
        {
            try
            {
                var tagetCourse = _courses.FirstOrDefault(c => c.id == courseId);
                tagetCourse.IsDeleted = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

    }
}
