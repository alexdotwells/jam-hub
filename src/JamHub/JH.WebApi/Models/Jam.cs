using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JH.WebApi.Models
{
    public class Jam
    {
        public string Description { get; set; }
        public decimal Rating { get; set; }
        public string JamCode { get; set; }
        public int JamId { get; set; }
        public string JamName { get; set; }
        public DateTime AdddedDate { get; set; }
    }
}