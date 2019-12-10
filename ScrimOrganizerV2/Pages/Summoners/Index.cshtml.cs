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
    public class IndexModel : PageModel
    {
        private readonly ScrimOrganizerV2.Data.ApplicationDbContext _context;

        public IndexModel(ScrimOrganizerV2.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Summoner> Summoner { get;set; }

        public async Task OnGetAsync()
        {
            Summoner = await _context.Summoner.ToListAsync();
        }
    }
}
