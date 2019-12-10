using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ScrimOrganizerV2.Data;
using ScrimOrganizerV2.Models;

namespace ScrimOrganizerV2.Pages.Summoners
{
    public class DetailsModel : PageModel
    {
        private readonly ScrimOrganizerV2.Data.ApplicationDbContext _context;

        public DetailsModel(ScrimOrganizerV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Summoner Summoner { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Summoner = await _context.Summoner.FirstOrDefaultAsync(m => m.id == id);

            if (Summoner == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
