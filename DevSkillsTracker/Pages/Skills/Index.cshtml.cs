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

        public IList<Skill> SkillList { get; set; }

        public async Task OnGetAsync()
        {
            var userId = _userManager.GetUserId(User);
            SkillList = await _context.Skills
                                      .Where(s => s.UserId == userId)
                                      .ToListAsync();
        }
    }
}
