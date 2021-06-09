using System.ComponentModel.DataAnnotations.Schema;

namespace Oleg.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        [ForeignKey("ThemeId")]
        public Theme Theme { get; set; }

        [ForeignKey("TeacherId")]
        public Teacher Teacher { get; set; }
    }
}
