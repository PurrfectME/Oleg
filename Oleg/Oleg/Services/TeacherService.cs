using Microsoft.EntityFrameworkCore;
using Oleg.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Oleg.Services
{
    public class TeacherService
    {
        private readonly ApplicationContext _context;

        public TeacherService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Teacher> GetAll()
        {
            return _context.Teachers
                .Include(x => x.Students)
                .ToList();
        }

        public Teacher GetById(int id)
        {
            return _context.Teachers.FirstOrDefault(x => x.Id == id);
        }

        public Teacher Add(Teacher entity)
        {
            var result = _context.Teachers.Add(entity).Entity;

            _context.SaveChanges();

            return result;
        }

        public void Delete(Teacher entity)
        {
            _context.Teachers.Remove(entity);

            _context.SaveChanges();
        }

    }
}
