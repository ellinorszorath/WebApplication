using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WebApplication3.Models
{
    public class Registrerad
    {
        [Key]
        public int Id { get; set; }
        public String Förnamn{ get; set; }
        public String Efternamn { get; set; }
        public DateTime Födelsedatum { get; set; }

    }
}
