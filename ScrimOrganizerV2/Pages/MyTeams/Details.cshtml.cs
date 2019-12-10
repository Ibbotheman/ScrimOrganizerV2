using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScrimOrganizerV2.Data;
using ScrimOrganizerV2.Models;

namespace ScrimOrganizerV2.Pages.MyTeams
{
    public class DetailsModel : PageModel
    {
        private readonly ScrimOrganizerV2.Data.ApplicationDbContext _context;

        public DetailsModel(ScrimOrganizerV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public MyTeam MyTeam { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            MyTeam = await _context.MyTeam.FirstOrDefaultAsync(m => m.ID == id);

            if (MyTeam == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
