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
        public Inlägg Inlägg { get; set; }
        public IEnumerable<Inlägg> InläggLista { get; set; }
    }

    

}
