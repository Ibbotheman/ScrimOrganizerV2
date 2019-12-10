using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrimOrganizerV2.Models
{
    public class Summoner
    {
        public int profileIconId { get; set; }
        public string name { get; set; }
        public string puuid { get; set; }
        public int summonerLevel { get; set; }
        public string accountId { get; set; }
        public string id { get; set; }
        public long revisionDate { get; set; }
        public string Role { get; set; }
        public int TeamID { get; set; }
        public Team Team { get; set; }

    }
}
