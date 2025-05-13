using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DevSkillsTracker.Web.Data;
using DevSkillsTracker.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;

namespace DevSkillsTracker.Web.Pages_LearningLogs
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public CreateModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }
        public SelectList SkillList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            SkillList = new SelectList(
                await _context.Skills.Where(s => s.UserId == userId).ToListAsync(),
                "Id", "Name"
            );

            return Page();
        }

        [BindProperty]
        public LearningLog LearningLog { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            LearningLog.UserId = _userManager.GetUserId(User);
            _context.LearningLogs.Add(LearningLog);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
