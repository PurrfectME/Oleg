using Microsoft.EntityFrameworkCore;
using Oleg.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Oleg.Services
{
    public class ThemeService
    {
        private readonly ApplicationContext _context;

        public ThemeService(ApplicationContext context)
        {
            _context = context;
        }

        public List<Theme> GetAll()
        {
            return _context.Themes
                .Include(x => x.Student)
                .ToList();
        }

        public Theme GetById(int id)
        {
            return _context.Themes.FirstOrDefault(x => x.Id == id);
        }

        public Theme Add(Theme entity)
        {
            try
            {
                var result = _context.Themes.Add(entity).Entity;

                _context.SaveChanges();

                return result;
            }
            catch (System.Exception)
            {
                return null;
            }
        }

        public void Delete(Theme entity)
        {
            _context.Themes.Remove(entity);

            _context.SaveChanges();
        }
    }
}
