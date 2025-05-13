using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevSkillsTracker.Web.Models
{
    public class LearningLog
    {
        public int Id { get; set; }

        [Required]
        public int SkillId { get; set; }

        [ForeignKey("SkillId")]
        public Skill Skill { get; set; }

        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        [Required]
        [Range(0.1, 24)]
        public double HoursSpent { get; set; }

        public string Notes { get; set; }

        [ScaffoldColumn(false)]
        public string? UserId { get; set; } // Make nullable

        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }
    }
}
