using System.ComponentModel.DataAnnotations;

namespace DevSkillsTracker.Web.Models
{
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }
    }
}

