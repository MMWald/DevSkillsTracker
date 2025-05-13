using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DevSkillsTracker.Web.Data;
using DevSkillsTracker.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DevSkillsTracker.Web.Pages.LearningLogs
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public IndexModel(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IList<LearningLog> LearningLog { get; set; }

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            LearningLog = await _context.LearningLogs
                .Include(l => l.Skill)
                .Where(l => l.UserId == userId)
                .OrderByDescending(l => l.Date)
                .ToListAsync();
        }
    }
}
