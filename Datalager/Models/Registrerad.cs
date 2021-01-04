using System;
using System.Collections.Generic;
using System.Text;

namespace Datalager.Models
{
    public class Registrerad
    {
        public int Id { get; set; }
        public string Namn { get; set; }
        public DateTime Födelsedatum { get; set; }
        public string Lösenord { get; set; }
    }
}
