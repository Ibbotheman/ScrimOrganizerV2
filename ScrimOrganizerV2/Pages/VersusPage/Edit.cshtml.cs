﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ScrimOrganizerV2.Data;
using ScrimOrganizerV2.Models;

namespace ScrimOrganizerV2.Pages.VersusPage
{
    public class EditModel : PageModel
    {
        private readonly ScrimOrganizerV2.Data.ApplicationDbContext _context;

        public EditModel(ScrimOrganizerV2.Data.ApplicationDbContext context)
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

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(VersusTeam).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VersusTeamExists(VersusTeam.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool VersusTeamExists(int id)
        {
            return _context.VersusTeam.Any(e => e.Id == id);
        }
    }
}
