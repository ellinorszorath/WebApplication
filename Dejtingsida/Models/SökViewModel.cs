using System;
using System.Collections.Generic;
using Datalager.Models;

namespace Dejtingsida.Models
{
    public class SökViewModel
    {
        public List<Registrerad> anvandare { get; set; }
        public string SökSträng { get; set; }
    }
}

