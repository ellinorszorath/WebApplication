using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datalager.Models;

namespace Dejtingsida.Viewmodels
{
    public class AnvandareViewModel
    {
        public virtual Registrerad Anvandare { get; set; }
        public virtual Inlägg Inlägg { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public DateTime Födelsedatum { get; set; }
        public string BildNamn { get; set; }
    }
    

}
