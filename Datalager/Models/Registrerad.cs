using System;
using Microsoft.AspNetCore.Identity;

namespace Datalager.Models
{
    public class Registrerad : IdentityUser
    {
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public DateTime Födelsedatum { get; set; }
        public string BildNamn { get; set; }
        public bool Visas { get; set; } = false;
    }
}
