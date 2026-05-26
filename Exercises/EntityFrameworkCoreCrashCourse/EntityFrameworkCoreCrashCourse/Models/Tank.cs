using EntityFrameworkCoreCrashCourse.Enums;
using System.ComponentModel.DataAnnotations;

namespace EntityFrameworkCoreCrashCourse.Models
{
    public class Tank
    {
        [Key]
        public int Id { get; set; }
        public int CommanderId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Nation Nation { get; set; }
        [Required]
        public int BattlesFought { get; set; }
    }
}
