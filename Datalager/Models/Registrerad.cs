using System;
using System.Collections.Generic;
using System.Text;

namespace Datalager.Models
{
    public class Registrerad
    {
        public int Id { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Användarnamn { get; set; }
        public DateTime Födelsedatum { get; set; }
        public string Lösenord { get; set; }
    }
}
