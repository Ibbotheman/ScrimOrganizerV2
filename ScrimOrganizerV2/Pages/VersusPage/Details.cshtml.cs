using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ScrimOrganizerV2.Data;
using ScrimOrganizerV2.Models;

namespace ScrimOrganizerV2.Pages.VersusPage
{
    public class DetailsModel : PageModel
    {
        private readonly ScrimOrganizerV2.Data.ApplicationDbContext _context;

        public DetailsModel(ScrimOrganizerV2.Data.ApplicationDbContext context, IHttpClientFactory clientFactory)
        {
            _context = context;
            _clientFactory = clientFactory;
        }

        public VersusTeam VersusTeam { get; set; }
        public IList<Summoner> Team1Summoners { get; set; }
        public IList<Summoner> Team2Summoners { get; set; }

        private readonly IHttpClientFactory _clientFactory;
        private string apikey = "RGAPI-e849876e-20c3-41b7-84c2-7752a7821690";
        private string baseUrl = "https://euw1.api.riotgames.com/lol/";
        public List<Class1> ShowStatsSummoner = new List<Class1>();
        public List<Class1> ShowStatsSummoner2 = new List<Class1>();

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            VersusTeam = await _context.VersusTeam.FirstOrDefaultAsync(m => m.Id == id);
            Team1Summoners = await _context.Summoner.Where(s => s.TeamID == VersusTeam.Team1ID).ToListAsync();
            Team2Summoners = await _context.Summoner.Where(s => s.TeamID == VersusTeam.Team2ID).ToListAsync();

            for (int i = 0; i < Team1Summoners.Count; i++)
            {
                string url = baseUrl + "league/v4/entries/by-summoner/" + Team1Summoners[i].id + "?api_key=" + apikey;
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var client = _clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    List<Class1> des = JsonConvert.DeserializeObject<List<Class1>>(json);

                    for (int j = 0; j < des.Count; j++)
                    {
                        if (des[j].queueType == "RANKED_SOLO_5x5")
                        {
                            ShowStatsSummoner.Add(des[j]);
                            break;
                        }
                    }
                }
            }

            for (int i = 0; i < Team2Summoners.Count; i++)
            {
                string url = baseUrl + "league/v4/entries/by-summoner/" + Team2Summoners[i].id + "?api_key=" + apikey;
                var request = new HttpRequestMessage(HttpMethod.Get, url);
                var client = _clientFactory.CreateClient();

                var response = await client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    List<Class1> des = JsonConvert.DeserializeObject<List<Class1>>(json);

                    for (int j = 0; j < des.Count; j++)
                    {
                        if (des[j].queueType == "RANKED_SOLO_5x5")
                        {
                            ShowStatsSummoner2.Add(des[j]);
                            break;
                        }
                    }
                }
            }

            if (VersusTeam == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}




            

