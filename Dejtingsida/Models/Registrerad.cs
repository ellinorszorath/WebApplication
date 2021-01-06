using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Registrerad
    {
        [Key]

        public String Användarnamn { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public DateTime Födelsedatum { get; set; }
        public string Lösenord { get; set; }
        public int Vänförfrågningar { get; set; }
        public string ProfilbildUrl { get; set; }

    }
}
