using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using DevSkillsTracker.Web.Data;
using DevSkillsTracker.Web.Models;

namespace DevSkillsTracker.Web.Pages.Skills
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
        public class SkillWithProgress
        {
            public Skill Skill { get; set; }
            public double TotalHours { get; set; }
            public double ProgressPercent => Skill.TargetHours.HasValue && Skill.TargetHours > 0
                ? Math.Min(100, (TotalHours / Skill.TargetHours.Value) * 100)
                : 0;
        }

        public IList<SkillWithProgress> SkillsWithProgress { get; set; }

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);

            var skills = await _context.Skills
                .Where(s => s.UserId == userId)
                .ToListAsync();

            var logs = await _context.LearningLogs
                .Where(l => l.UserId == userId)
                .ToListAsync();

            SkillsWithProgress = skills
                .Select(s => new SkillWithProgress
                {
                    Skill = s,
                    TotalHours = logs.Where(l => l.SkillId == s.Id).Sum(l => l.HoursSpent)
                }).ToList();
        }
    }
}
