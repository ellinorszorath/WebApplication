using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Profil
    {
        public String Förnamn { get; set; }
        public String Efternamn { get; set; }
        public String Användarnamn { get; set; }
        public DateTime Födelsedatum { get; set; }
        public string Lösenord { get; set; }
        public int Vänförfrågningar { get; set; }

    }
}
