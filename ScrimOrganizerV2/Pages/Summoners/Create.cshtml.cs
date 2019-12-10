using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ScrimOrganizerV2.Data;
using ScrimOrganizerV2.Models;

namespace ScrimOrganizerV2.Pages.Summoners
{
    public class CreateModel : PageModel
    {
        private readonly ScrimOrganizerV2.Data.ApplicationDbContext _context;
        private readonly IHttpClientFactory _clientFactory;
        //Husk at opdater API nøglen hvis programmet ikke virker
        private string apikey = "RGAPI-afbe7439-32a9-48af-bff9-58d25dc85c86";
        private string baseUrl = "https://euw1.api.riotgames.com/lol/";
        public CreateModel(ScrimOrganizerV2.Data.ApplicationDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        public IActionResult OnGet()
        {
            if (id == 0)
            {
                return RedirectToPage("/Index");
            }
            return Page();
        }


        //Summoner = await GetSummoner(apikey, username);


        [BindProperty(SupportsGet = true)]
        public int id { get; set; }

        [BindProperty]
        public Summoner Summoner { get; set; }


        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                string role = Summoner.Role;
                string url = baseUrl + "summoner/v4/summoners/by-name/" + Summoner.name + "?api_key=" + apikey;
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var client = _clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    Summoner = JsonConvert.DeserializeObject<Summoner>(json);
                    Summoner.Role = role;
                    Summoner.TeamID = id;
                }
                _context.Summoner.Add(Summoner);
                await _context.SaveChangesAsync();
                

                return RedirectToPage("./Index");
            }
            else
            {
                return Page();
            }


        }
    }
}
