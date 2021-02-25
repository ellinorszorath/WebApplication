using System;
using System.Collections.Generic;
using Datalager.Models;

namespace Dejtingsida.Models
{
    public class VännerViewModel
    {
        public string Registrerad { get; set; }
        public List<Vänförfrågning> Vänförfrågningar { get; set; }

    }
}
