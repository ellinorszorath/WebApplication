using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Datalager.Models
{
    public class Vänförfrågning
    {
        public int Id { get; set; }

        [Required]
        public bool Accepterad { get; set; } = false;

        [Required]
        public DateTime FörfrågningsDatum { get; set; }

        [Required]
        public string MottagareID { get; set; }

        [Required]
        public string FörfrågareID { get; set; }


    }
}
