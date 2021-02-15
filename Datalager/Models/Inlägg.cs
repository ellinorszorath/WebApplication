using System;
using System.Collections.Generic;
using System.Text;

namespace Datalager.Models
{
    public class Inlägg
    {
        public int Id { get; set; }
        public DateTime Skapad { get; set; }
        public virtual Registrerad Sender { get; set; }
        public virtual Registrerad Mottagare { get; set; }
    }
}
