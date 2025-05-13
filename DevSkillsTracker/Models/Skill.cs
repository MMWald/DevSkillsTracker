using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DevSkillsTracker.Web.Models
{
    [Authorize]
    public class Skill
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [ScaffoldColumn(false)]
        public string? UserId { get; set; } // Make nullable

        [ForeignKey("UserId")]
        public IdentityUser? User { get; set; }
    }
}

