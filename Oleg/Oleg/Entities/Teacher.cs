using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Oleg.Entities
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [MaxLength(7)]
        public List<Student> Students { get; set; }
    }
}
