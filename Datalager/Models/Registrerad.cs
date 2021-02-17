﻿using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text;

namespace Datalager.Models
{
    public class Registrerad : IdentityUser
    {
        public string Användarnamn { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public DateTime Födelsedatum { get; set; }
        public string BildNamn { get; set; }
        public byte[] Bild { get; set; }
        //public int Id { get; set; }
        //public string Email { get; set; }
        public string Lösenord { get; set; }
        

    }
}
