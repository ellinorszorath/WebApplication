using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Datalager.Models;

namespace Dejtingsida.Models
{
    public class Inlägg
    {
        public int Id { get; set; }
        public DateTime Skapad { get; set; }
        public virtual Registrerad Användare { get; set; }
        public string Text { get; set; }
    }
}

