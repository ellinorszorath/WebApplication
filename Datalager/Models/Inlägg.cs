using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text;

namespace Datalager.Models
{
    public class Inlägg
    {       
        public string Message { get; set; }
        public int Id { get; set; }
        public DateTime Skapad { get; set; }
        public virtual string MottagareID { get; set; }
        public virtual string SkickareID { get; set; }
    }
}
