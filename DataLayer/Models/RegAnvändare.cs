using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    class RegAnvändare
    {
        public int Id { get; set; }
        public String Förnamn { get; set; }
        public String Efternamn { get; set; }
        public DateTime Födelsedatum { get; set; }
    }
}

