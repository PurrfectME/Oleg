using Microsoft.EntityFrameworkCore;
using Oleg;
using Oleg.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Diplom.Services
{
    public class StudentService
    {
        private readonly ApplicationContext _context;

        public StudentService(ApplicationContext context)
        {
            _context = context;
        }

        public Student Add(Student entity)
        {
            var result = _context.Students.Add(entity).Entity;

            _context.SaveChanges();

            return result;
        }

        public void Delete(Student entity)
        {
            _context.Students.Remove(entity);

            _context.SaveChanges();
        }

        public List<Student> GetAll()
        {
            return _context.Students
                .Include(x => x.Theme)
                .Include(x => x.Teacher)
                .ToList();
        }

        public Student GetByName(string name)
        {
            return _context.Students.FirstOrDefault(x => x.Name == name);
        }

        public Student GetById(int id)
        {
            return _context.Students.FirstOrDefault(x => x.Id == id);
        }

        public Student AssignToTheme(Student student, Theme theme)
        {
            if (theme.Student != null)
            {
                return null;
            }

            student.Theme = theme;

            var result = _context.Students.Update(student).Entity;

            _context.SaveChanges();

            return result;
        }

        public Student AssignToTeacher(Student student, Teacher teacher)
        {
            if (teacher.Students.Count == 7)
            {
                return null;
            }

            student.Teacher = teacher;

            var result = _context.Students.Update(student).Entity;

            _context.SaveChanges();

            return result;
        }
    }
}
