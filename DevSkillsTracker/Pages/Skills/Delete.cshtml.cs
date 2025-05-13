using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DevSkillsTracker.Web.Data;
using DevSkillsTracker.Web.Models;
using Microsoft.AspNetCore.Authorization;

namespace DevSkillsTracker.Web.Pages_Skills
{
    [Authorize]
    public class DeleteModel : PageModel
    {
        private readonly DevSkillsTracker.Web.Data.ApplicationDbContext _context;

        public DeleteModel(DevSkillsTracker.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills.FindAsync(id);
            if (skill != null)
            {
                Skill = skill;
                _context.Skills.Remove(Skill);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
