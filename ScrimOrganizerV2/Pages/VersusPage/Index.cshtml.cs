using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScrimOrganizerV2.Data;
using ScrimOrganizerV2.Models;

namespace ScrimOrganizerV2.Pages.VersusPage
{
    public class IndexModel : PageModel
    {
        private readonly ScrimOrganizerV2.Data.ApplicationDbContext _context;

        public IndexModel(ScrimOrganizerV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<VersusTeam> VersusTeam { get;set; }
        public IList<Team> Teams { get; set; }

        public async Task OnGetAsync()
        {
            VersusTeam = await _context.VersusTeam.ToListAsync();
            Teams = await _context.Team.ToListAsync();
        }
    }
}
