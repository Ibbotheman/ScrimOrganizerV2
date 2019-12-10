using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScrimOrganizerV2.Models
{
    public class Users
    {
        public int UserID { get; set; }

        //Bruger ID fra asp.net tabelen
        public string OwnerID  { get; set; }

        public string Name { get; set; }
        public string Email { get; set; }
        
    }
}
