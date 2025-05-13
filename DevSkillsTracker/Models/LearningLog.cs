using System;
using System.ComponentModel.DataAnnotations;

namespace DevSkillsTracker.Web.Models
{
    public class LearningLog
    {
        public int Id { get; set; }

        [Required]
        public int SkillId { get; set; }
        public Skill Skill { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public double HoursSpent { get; set; }

        public string Notes { get; set; }
    }
}
