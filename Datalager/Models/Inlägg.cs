using System;

namespace Datalager.Models
{
    public class Inlägg
    {       
        public string Message { get; set; }
        public string MottagareID { get; set; }
        public string SkickareID { get; set; }
        public int Id { get; set; }
        public DateTime Skapad { get; set; }


    }
}
