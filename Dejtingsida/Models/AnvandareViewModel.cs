using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datalager.Models;

namespace Dejtingsida.Models
{
    public class AnvandareViewModel
    {
        public Registrerad Anvandare { get; set; }
        public Inlägg inlägg { get; set; }
        //public string Förnamn { get; set; }
        //public string Efternamn { get; set; }
        //public DateTime Födelsedatum { get; set; }
        //public string BildNamn { get; set; }
        //public IEnumerable<Registrerad> AnvändarLista { get; set; }
        public IEnumerable<Inlägg> InläggLista { get; set; }
    }

    

}
