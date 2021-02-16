using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text;

namespace Datalager.Models
{
    public class Vänförfrågning
    {
        public int Id { get; set; }
        public virtual Registrerad Mottagare { get; set; }
    }
}
