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
    public class DeleteModel : PageModel
    {
        private readonly ScrimOrganizerV2.Data.ApplicationDbContext _context;

        public DeleteModel(ScrimOrganizerV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public VersusTeam VersusTeam { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VersusTeam = await _context.VersusTeam.FirstOrDefaultAsync(m => m.Id == id);

            if (VersusTeam == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VersusTeam = await _context.VersusTeam.FindAsync(id);

            if (VersusTeam != null)
            {
                _context.VersusTeam.Remove(VersusTeam);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
