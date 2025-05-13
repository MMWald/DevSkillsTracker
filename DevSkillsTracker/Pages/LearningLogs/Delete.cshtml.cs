using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DevSkillsTracker.Web.Data;
using DevSkillsTracker.Web.Models;

namespace DevSkillsTracker.Web.Pages_LearningLogs
{
    public class DeleteModel : PageModel
    {
        private readonly DevSkillsTracker.Web.Data.ApplicationDbContext _context;

        public DeleteModel(DevSkillsTracker.Web.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public LearningLog LearningLog { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learninglog = await _context.LearningLogs.FirstOrDefaultAsync(m => m.Id == id);

            if (learninglog == null)
            {
                return NotFound();
            }
            else
            {
                LearningLog = learninglog;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var learninglog = await _context.LearningLogs.FindAsync(id);
            if (learninglog != null)
            {
                LearningLog = learninglog;
                _context.LearningLogs.Remove(LearningLog);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
