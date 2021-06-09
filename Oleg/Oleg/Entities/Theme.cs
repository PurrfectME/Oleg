using System.ComponentModel.DataAnnotations;

namespace Oleg.Entities
{
    public class Theme
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }

        public Student Student { get; set; }
    }
}
