using DevSkillsTracker.Web.Data;
using DevSkillsTracker.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace DevSkillsTracker.Web.Pages.Dashboard
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

        public double TotalHours { get; set; }
        public int TotalSessions { get; set; }
        public string TopSkillName { get; set; } = "N/A";

        public List<string> SkillNames { get; set; } = new();
        public List<double> HoursPerSkill { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);

            var logs = await _context.LearningLogs
                .Include(l => l.Skill)
                .Where(l => l.UserId == userId)
                .ToListAsync();

            TotalHours = logs.Sum(l => l.HoursSpent);
            TotalSessions = logs.Count;

            var grouped = logs
                .GroupBy(l => l.Skill.Name)
                .Select(g => new
                {
                    SkillName = g.Key,
                    TotalHours = g.Sum(x => x.HoursSpent)
                })
                .OrderByDescending(x => x.TotalHours)
                .ToList();

            if (grouped.Any())
                TopSkillName = grouped.First().SkillName;

            SkillNames = grouped.Select(x => x.SkillName).ToList();
            HoursPerSkill = grouped.Select(x => x.TotalHours).ToList();

            return Page();
        }
    }
}
