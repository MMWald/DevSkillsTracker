using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DevSkillsTracker.Web.Data;
using DevSkillsTracker.Web.Models;

namespace DevSkillsTracker.Web.Pages_Skills
{
    public class DetailsModel : PageModel
    {
        private readonly DevSkillsTracker.Web.Data.ApplicationDbContext _context;

        public DetailsModel(DevSkillsTracker.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Skill Skill { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills.FirstOrDefaultAsync(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }
            else
            {
                Skill = skill;
            }
            return Page();
        }
    }
}
