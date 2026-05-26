using EntityFrameworkCoreCrashCourse.Enums;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreCrashCourse.Models
{
    public class Commander
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public Gender Gender { get; set; }
    }
}
