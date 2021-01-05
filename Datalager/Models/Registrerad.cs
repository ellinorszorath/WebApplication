using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text;

namespace Datalager.Models
{
    public class Registrerad : IdentityUser
    {
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public DateTime Födelsedatum { get; set; }
        public string Lösenord { get; set; }
        public int Vänförfrågningar { get; set; }
        public string ProfilbildUrl { get; set; }

    }
}
